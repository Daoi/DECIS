using DECIS.ControlLogic.Gridview;
using DECIS.ControlLogic.Panels;
using DECIS.DataAccess.DataAccessors;
using DECIS.DataAccess.DataAccessors.Organization;
using DECIS.DataModels;
using DECIS.PageLogic.OrgView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class OrgView : Page
    {
        int orgID;
        BindGridviews binder;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["orgid"], out orgID))
                Response.Redirect("./OrgList.aspx");

            if (!IsPostBack)
            {
                ViewState["AssetListDT"] = new GetAllAssets().ExecuteCommand();
                DataRow drInfo = new GetOrgByID().ExecuteCommand(orgID).Rows[0];
                Organization org = new Organization(drInfo);
                ViewState["Org"] = org;
                OrgViewDataDisplay.Display(Page, org);
                TogglePanel.ToggleInputs(pnlControls);
                binder = new BindGridviews(orgID);
                binder.Bind(new List<GridView>() {gvRequests, gvPeople } );
                ViewState["DataBinder"] = binder;
            }
            binder = ViewState["DataBinder"] as BindGridviews;
        }
        
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ViewState["Editing"] != null && (bool)ViewState["Editing"]) //If we're in edit mode
            {
                //Save currently selected values
                Organization newOrg = CreateNewOrg.Create(Page, orgID);
                int x = new UpdateOrg(newOrg).ExecuteCommand();
                Response.Redirect($"./OrgView.aspx?orgid={orgID}");
            }

            //Initialize or update Editing State value
            ViewState["Editing"] = ViewState["Edting"] == null ? ViewState["Editing"] = true : !(bool)ViewState["Editing"];

            //Setup display
            TogglePanel.ToggleInputs(pnlControls);
            btnCancelEdit.Visible = !btnCancelEdit.Visible;
            btnEdit.Text = btnEdit.Text == "Edit" ? "Save" : "Edit";
        }

        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
            //Setup display
            TogglePanel.ToggleInputs(pnlControls, true);
            btnCancelEdit.Visible = false;
            btnEdit.Text = "Edit";
        }

        protected void lnkBtnView_Click(object sender, EventArgs e)
        {
            //Get the row containing the clicked button
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            //Recreate the Datarow the GVR is bound to
            DataRow dr = (ViewState["AssetListDT"] as DataTable).Rows[row.DataItemIndex];
            Asset asset = new Asset(dr);
            string test = hfActiveTab.Value;
            Session["CurrentAsset"] = asset;
            Response.Redirect("./AssetView.aspx");
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadOrgDocuments.Download(ViewState["Org"] as Organization);
        }
    }
}