using DECIS.ControlLogic.Gridview;
using DECIS.ControlLogic.Panels;
using DECIS.DataAccess.DataAccessors;
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

            HeaderBinding.CreateHeaders(new List<GridView>() { gvComputers, gvAssigned });

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
                        PersonalRequest req = new PersonalRequest(new GetRequestInfoByID().ExecuteCommand(reqID, type).Rows[0]);
                        ViewState["Request"] = req;
                        DisplayRequest.Display(Page, req);
                    }
                    BindGridviews.Bind(Page, reqID);
                }
                catch (Exception ex)
                {
                    Response.Redirect("./RequestList.aspx");
                }

                TogglePanel.ToggleInputs(pnlControls);
                TogglePanel.ToggleInputs(pnlPeripheral);
            }

        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ViewState["Editing"] != null && (bool)ViewState["Editing"]) //If we're in edit mode
            {
                //Save currently selected values
                Request orgReq = ViewState["Request"] as Request;
                if (orgReq.Type == 0)
                {
                    OrgRequest newReq = CreateOrgRequest.Create(Page, orgReq.OrgID);
                    new UpdateOrgRequest(newReq).ExecuteCommand();
                }
                Response.Redirect($"./RequestView.aspx?reqid={reqID}&type={type}");
            }
            
            //Initialize or update Editing State value
            ViewState["Editing"] = ViewState["Edting"] == null ? ViewState["Editing"] = true : !(bool)ViewState["Editing"];

            //Setup display
            TogglePanel.ToggleInputs(pnlControls);
            TogglePanel.ToggleInputs(pnlPeripheral);
            btnCancelEdit.Visible = !btnCancelEdit.Visible;
            btnEdit.Text = btnEdit.Text == "Edit" ? "Save" : "Edit";
        }

        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
            //Setup display
            TogglePanel.ToggleInputs(pnlControls);
            TogglePanel.ToggleInputs(pnlPeripheral);
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
            DataRow dr = (ViewState["AssetListDT"] as DataTable).Rows[row.DataItemIndex];
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
    }
}