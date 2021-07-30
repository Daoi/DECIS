using DECIS.ControlLogic.Panels;
using DECIS.ControlLogic.DDL;
using DECIS.DataAccess.DataAccessors.Location;
using DECIS.DataAccess.DataAccessors.Model;
using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using DECIS.DataAccess.DataAccessors.Assets;
using DECIS.CotrolLogic;


namespace DECIS
{
    public partial class AssetView : System.Web.UI.Page
    {
        Asset curAsset;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentAsset"] != null)
                curAsset = Session["CurrentAsset"] as Asset;
            else
                Response.Redirect("./AssetList.aspx");

            if (!IsPostBack)
            {
                RetrieveData();
                FormatCard();
            }

        }

        private void FormatCard()
        {
            //Setup asset info display
            crdAssetImage.Src = curAsset.Image;
            lblSerialNumber.Text = $"Serial Number: {curAsset.SerialNumber} | Asset ID: {curAsset.AssetID} | Intake ID: {curAsset.IntakeID}";
            tbAssetDescription.Text = curAsset.Description;
            lblAssetTypeText.Text = curAsset.AssetType;
            lblLocationDescriptionText.Text = curAsset.LocationDescription;
            SetItem.SetItemByText(ddlAssetMake, curAsset.Make);
            SetItem.SetItemByText(ddlAssetModel, curAsset.Model);
            SetItem.SetItemByText(ddlAssetStatus, curAsset.Status);
            SetItem.SetItemByText(ddlLocation, curAsset.Location);
            //Disable on page first load(Not in edit mode yet)
            TogglePanel.ToggleInputs(pnlControls, true);
        }

        private void RetrieveData()
        {
            List<DropDownList> ddls = new List<DropDownList>() { ddlAssetMake, ddlAssetModel, ddlAssetStatus, ddlLocation };
            DataSet dts = DDLDataBind.ddlBind(ddls, curAsset.MakeID);
            ViewState["Models"] = dts.Tables["Model"];
            ViewState["Locations"] = dts.Tables["Location"];
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {   
            if (ViewState["Editing"] != null && (bool)ViewState["Editing"]) //If we're in edit mode
            {
                //Save currently selected values
                //Maybe combine these into the normal DTs for the page to reduce queries
                DataTable modelInfoDT = new GetModelInfoByID().ExecuteCommand(int.Parse(ddlAssetModel.SelectedValue));
                DataTable locationInfoDT = new GetLocationInfoByID().ExecuteCommand(int.Parse(ddlLocation.SelectedValue));
                Asset newAsset = new Asset()
                {
                    AssetID = curAsset.AssetID,
                    SerialNumber = curAsset.SerialNumber,
                    Model = ddlAssetModel.SelectedItem.ToString(),
                    ModelID = int.Parse(ddlAssetModel.SelectedValue),
                    Make = ddlAssetMake.SelectedItem.ToString(),
                    MakeID = int.Parse(ddlAssetMake.SelectedValue),
                    AssetType = modelInfoDT.Rows[0].Field<string>("AssetType"),
                    Description = tbAssetDescription.Text,
                    Location = ddlLocation.SelectedItem.ToString(),
                    LocationID = int.Parse(ddlLocation.SelectedValue),
                    LocationDescription = locationInfoDT.Rows[0].Field<string>("LocationDescription"),
                    Status = ddlAssetStatus.SelectedItem.ToString(),
                    StatusID = int.Parse(ddlAssetStatus.SelectedValue),
                    Image = modelInfoDT.Rows[0].Field<string>("Image"),
                    IntakeID = curAsset.IntakeID
                };

                int x = new UpdateAsset(newAsset).ExecuteCommand(); //variable is unused currently, can be used to check success/failure

                Session["CurrentAsset"] = newAsset;
                Response.Redirect("./AssetView.aspx");
            }

            //Initialize or update Editing State value
            ViewState["Editing"] = ViewState["Edting"] == null ? ViewState["Editing"] = true : !(bool)ViewState["Editing"];

            //Setup display
            TogglePanel.ToggleInputs(pnlControls, true);
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

        protected void ddlAssetMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;  
            int index = int.Parse(ddl.SelectedValue);
            DataTable modelDT = ViewState["Models"] as DataTable;

            ddlAssetModel.DataSource = modelDT.AsEnumerable()
                .Where(r => r.Field<int>("Make") == index)
                .CopyToDataTable();
            ddlAssetModel.DataTextField = "Model";
            ddlAssetModel.DataValueField = "ModelID";
            ddlAssetModel.DataBind();

            ddlAssetModel.SelectedIndex = 0;
            upMakeModel.Update();

        }

        protected void btnViewIntake_Click(object sender, EventArgs e)
        {
            Response.Redirect($"./IntakeView.aspx?intid={curAsset.IntakeID}");
        }
    }
}