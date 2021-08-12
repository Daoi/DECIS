using DECIS.ControlLogic.Gridview;
using DECIS.ControlLogic.Panels;
using DECIS.DataAccess.DataAccessors.Assets;
using DECIS.DataAccess.DataAccessors.Intake;
using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class IntakeView : System.Web.UI.Page
    {
        int intID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["intid"], out intID))
                Response.Redirect("./IntakeList.aspx");

            if (!IsPostBack)
            {
                HeaderBinding.CreateHeaders(gvAssetList);

                DataRow drInfo = new GetIntakeByID().ExecuteCommand(intID).Rows[0];
                DataTable dtAssets = new GetAssetsByIntake().ExecuteCommand(intID);
                Intake it = new Intake(drInfo);
                //Organization org = new Organization(drInfo);
                //ViewState["org"] = org;
                ViewState["it"] = it;
                ViewState["Assets"] = dtAssets;

                gvAssetList.DataSource = dtAssets;
                gvAssetList.DataBind();

                SetupDisplay();
            }
        }

        private void SetupDisplay()
        {
            TogglePanel.ToggleInputs(pnlControls);
            Intake it = ViewState["it"] as Intake;
            lblPrimaryEmailText.Text = it.PrimaryEmail;
            lblPrimaryPhoneText.Text = it.PrimaryPhone;
            lblPrimaryContactText.Text = it.PrimaryContact;
            lblCardTitle.Text = $"Donating Org: {it.OrgName} | Donation Date: {it.IntakeDate}";

            tbIntakeNotes.Text = it.IntakeNotes;
            lblOrgAddressText.Text = it.OrgAddress;
            lblOrgEmailText.Text = it.OrgEmail;
            lblOrgPhoneText.Text = it.OrgPhone;
        }

        protected void lnkBtnView_Click(object sender, EventArgs e)
        {
            //Get the row containing the clicked button
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            //Recreate the Datarow the GVR is bound to
            DataRow dr = (ViewState["AssetListDT"] as DataTable).Rows[row.DataItemIndex];
            Asset asset = new Asset(dr);

            Session["CurrentAsset"] = asset;
            Response.Redirect("./AssetView.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ViewState["Editing"] != null && (bool)ViewState["Editing"]) //If we're in edit mode
            {
                //Save currently selected values
                new UpdateIntake().ExecuteCommand(intID, tbIntakeNotes.Text);

                Response.Redirect($"./IntakeView.aspx?intid={intID}");
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

    }
}