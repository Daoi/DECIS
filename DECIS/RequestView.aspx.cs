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

            if (!IsPostBack)
            {
                ViewState["Add"] = new List<int>();
                ViewState["Remove"] = new List<int>();
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

                }
                catch(Exception ex)
                {
                    Response.Redirect("./RequestList.aspx");
                }

                assetsToAdd = ViewState["Add"] as List<int>;
                assetsToRemove = ViewState["Remove"] as List<int>;
                TogglePanel.ToggleInputs(pnlControls);
                TogglePanel.ToggleInputs(pnlPeripheral);
            }

            BindGridviews.Bind(Page, reqID);
            HeaderBinding.CreateHeaders(new List<GridView>() { gvComputers, gvAssigned });
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
            assetsToAdd = new List<int>();
            gvComputers.Rows.OfType<GridViewRow>()
                .Where(gvr => (gvr.FindControl("cbSelected") as CheckBox).Checked)
                .ToList()
                .ForEach(gvr => assetsToAdd.Add(int.Parse((gvr.FindControl("hfAssetID") as HiddenField).Value)));
            AddAssets.Add(assetsToAdd, reqID);
            BindGridviews.Bind(Page, reqID);
            
        }
    }
}