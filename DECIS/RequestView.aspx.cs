using DECIS.ControlLogic.Gridview;
using DECIS.ControlLogic.Panels;
using DECIS.DataAccess.DataAccessors;
using DECIS.DataAccess.DataAccessors.Assets;
using DECIS.DataAccess.DataAccessors.Request;
using DECIS.DataModels;
using DECIS.PageLogic.RequestView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class RequestView : System.Web.UI.Page
    {
        int reqID;
        int type; //0 = Org, 1 = Personal
        List<int> assetsToAdd;
        List<int> assetsToRemove;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["reqid"], out reqID))
                Response.Redirect("./RequestList.aspx");
            if (ViewState["Type"] == null)
            {
                if (!int.TryParse(Request.QueryString["type"], out type))
                    Response.Redirect("./RequestList.aspx");
            }
            else
                type = (int)ViewState["Type"]; //Try to prevent people breaking the webpage by manually changing type, kind of dumb/pointless

            if (!IsPostBack)
            {
                Session["Add"] = new List<int>();
                Session["Remove"] = new List<int>();
                ViewState["Type"] = type;
                Session["AssetListDT"] = new GetAllAssets().ExecuteCommand();
                try
                {
                    if (type == 0)
                    {
                        OrgRequest req = new OrgRequest(new GetRequestInfoByID().ExecuteCommand(reqID, type).Rows[0]);
                        ViewState["Request"] = req;
                        DisplayRequest.Display(Page, req);
                    }
                    else
                    {
                        DataRow info = new GetRequestInfoByID().ExecuteCommand(reqID, type).Rows[0];
                        PersonalRequest req = new PersonalRequest(info);
                        Person p = new Person(info);
                        ViewState["Request"] = req;
                        DisplayRequest.Display(Page, req, p);
                    }
                    BindGridviews.Bind(Page, reqID);
                }
                catch (Exception ex)
                {
                    Response.Redirect("./RequestList.aspx");
                }

                TogglePanel.ToggleInputs(pnlControls);
                TogglePanel.ToggleInputs(pnlPeripheral);
                TogglePanel.ToggleInputs(pnlDDLs);

            }
            int status = (ViewState["Request"] as Request).Status;
            //If Finished(4) or Cancelled(5)
            if (status >= 4 && (Session["User"] as User).Role != (int)Permission.Admin)
            {
                btnEdit.Visible = false;
                btnAddAll.Visible = false;
                btnRemoveAll.Visible = false;
                gvComputers.Visible = false;
            }
            
            if(status >= 3)
            {
                btnViewForm.Visible = true;
            }

        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ViewState["Editing"] != null && (bool)ViewState["Editing"]) //If we're in edit mode
            {
                //Save currently selected values
                Request req = ViewState["Request"] as Request;
                if (req.Type == 0)
                {
                    OrgRequest newReq = CreateOrgRequest.Create(Page, req.RequestID);
                    if (!string.IsNullOrWhiteSpace(newReq.DateScheduled) && newReq.Status != 3)
                        newReq.Status = 3;
                    new UpdateOrgRequest(newReq).ExecuteCommand();
                }
                else
                {
                    PersonalRequest newReq = CreatePersonalRequest.Create(Page, req.RequestID);
                    if (!string.IsNullOrWhiteSpace(newReq.DateScheduled) && newReq.Status < 3)
                        newReq.Status = 3;
                    new UpdatePersonalRequest(newReq).ExecuteCommand();

                }
                Response.Redirect($"./RequestView.aspx?reqid={reqID}&type={type}");
            }
            int status = (ViewState["Request"] as Request).Status;
            
            //If Finished(4) or Cancelled(5)
            if (status >= 4 && (Session["User"] as User).Role != (int)Permission.Admin)
                return;

            //Initialize or update Editing State value
            ViewState["Editing"] = ViewState["Edting"] == null ? ViewState["Editing"] = true : !(bool)ViewState["Editing"];

            //Setup display
            TogglePanel.ToggleInputs(pnlControls);
            TogglePanel.ToggleInputs(pnlPeripheral);
            TogglePanel.ToggleInputs(pnlDDLs);
            btnCancelEdit.Visible = !btnCancelEdit.Visible;
            btnEdit.Text = btnEdit.Text == "Edit" ? "Save" : "Edit";
        }

        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
            //Setup display
            TogglePanel.ToggleInputs(pnlControls);
            TogglePanel.ToggleInputs(pnlPeripheral);
            TogglePanel.ToggleInputs(pnlDDLs);
            btnCancelEdit.Visible = false;
            btnEdit.Text = "Edit";
        }

        protected void btnViewOrg_Click(object sender, EventArgs e)
        {
            Request req = ViewState["Request"] as Request;
            Response.Redirect($"./OrgView.aspx?orgid={req.OrgID.ToString()}");
        }


        protected void lnkBtnView_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int x = int.Parse((row.Cells[0].FindControl("hfAssetID") as HiddenField ?? row.Cells[0].FindControl("hfAssetIDR") as HiddenField).Value);
            DataRow dr = (Session["AssetListDT"] as DataTable).AsEnumerable().First(r => r.Field<int>("AssetID") == x);
            Asset asset = new Asset(dr);
            //This should be changed to use querystring or something like other view pages
            Session["CurrentAsset"] = asset;
            Response.Redirect("./AssetView.aspx");
        }

        protected void btnAddAll_Click(object sender, EventArgs e)
        {
            if((Session["Add"] as List<int>).Count == 0)
            {
                //Lbl error message none selected
                return;
            }
            else
                AddAssets.Add(Session["Add"] as List<int>, reqID);

            Response.Redirect($"./RequestView.aspx?reqid={reqID}&type={type}");
        }

        protected void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if ((Session["Remove"] as List<int>).Count == 0)
            {
                //Lbl error message none selected
                return;
            }
            else
                RemoveAssets.Remove(Session["Remove"] as List<int>, reqID);

            Response.Redirect($"./RequestView.aspx?reqid={reqID}&type={type}");
        }

        protected void cbSelectedAdd_CheckedChanged(object sender, EventArgs e)
        {
            assetsToAdd = (List<int>)Session["Add"];

            CheckBox cb = (CheckBox)sender;
            int id = int.Parse((cb.Parent.FindControl("hfAssetID") as HiddenField).Value);

            if (cb.Checked && !assetsToAdd.Contains(id))
                assetsToAdd.Add(id);
            else if(!cb.Checked && assetsToAdd.Contains(id))
                assetsToAdd.Remove(id);

            Session["Add"] = assetsToAdd;

        }
        protected void cbSelectedRemove_CheckedChanged(object sender, EventArgs e)
        {
            assetsToRemove = (List<int>)Session["Remove"];

            CheckBox cb = (CheckBox)sender;
            int id = int.Parse((cb.Parent.FindControl("hfAssetIDR") as HiddenField).Value);

            if (cb.Checked && !assetsToRemove.Contains(id))
                assetsToRemove.Add(id);
            else if (!cb.Checked && assetsToRemove.Contains(id))
                assetsToRemove.Remove(id);

            Session["Remove"] = assetsToRemove;

        }

        protected void btnViewForm_Click(object sender, EventArgs e)
        {
            Response.Redirect($"./DonationDocument/DonationForm.aspx?id={reqID}&type={type}");
        }
    }
}