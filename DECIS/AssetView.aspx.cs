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
using DECIS.CotrolLogic.DDL;
using DECIS.PageLogic.AssetView;

namespace DECIS
{
    public partial class AssetView : System.Web.UI.Page
    {
        public Asset curAsset;
        AssetPage pageContainer;
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["CurrentAsset"] != null)
                curAsset = Session["CurrentAsset"] as Asset;
            else
                Response.Redirect("./AssetList.aspx");

            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AssetViewContainer"] == null)
            {
                pageContainer = new AssetPage(Page);
                Session["AssetViewContainer"] = pageContainer;
            }
            else
                pageContainer = Session["AssetViewContainer"] as AssetPage;

            if (!IsPostBack)
            {
                hfAssetID.Value = curAsset.AssetType;
                hfSerialNumber.Value = curAsset.SerialNumber;
                RetrieveData();
                DisplayAsset.Display(pageContainer, curAsset);
            }
        }

        private void RetrieveData()
        {
            List<DropDownList> ddls = new List<DropDownList>() { ddlAssetMake, ddlAssetModel, ddlAssetStatus, ddlLocation };
            DataSet dts = DDLDataBind.Bind(ddls, curAsset.MakeID);
            ViewState["Models"] = dts.Tables["Model"];
            ViewState["Locations"] = dts.Tables["Location"];
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            
            if (ViewState["Editing"] != null && (bool)ViewState["Editing"]) //If we're in edit mode
            {
                //Save currently selected values
                //Maybe combine these into the normal DTs for the page to reduce queries
                if (ddlAssetModel.SelectedValue == "Invalid" || ddlLocation.SelectedValue == "Invalid")
                {
                    //error message
                    return;
                }

                DataTable modelInfoDT = new GetModelInfoByID().ExecuteCommand(int.Parse(ddlAssetModel.SelectedValue));
                DataTable locationInfoDT = new GetLocationInfoByID().ExecuteCommand(int.Parse(ddlLocation.SelectedValue));

                Asset newAsset = new CreateAsset(pageContainer).Create();
                newAsset.IntakeID = curAsset.IntakeID;

                int x = new UpdateAsset(newAsset).ExecuteCommand(); //variable is unused currently, can be used to check success/failure

                Session["CurrentAsset"] = newAsset;
                Response.Redirect("./AssetView.aspx");
            }
            
            //Donated and Recycled Items can't be edited
            if (curAsset.StatusID == 5 || curAsset.StatusID == 6)
                return;
            
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
            btnCancelEdit.Visible = false;
            btnEdit.Text = "Edit";
            DisplayAsset.Display(pageContainer, curAsset);
            //reset model drop down
            List<DropDownList> l = new List<DropDownList>() { ddlAssetModel };
            DDLDataBind.Bind(l, curAsset.MakeID);
            //Fix model no updating
        }

        protected void ddlAssetMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;  
            int index = int.Parse(ddl.SelectedValue);
            DataTable modelDT = ViewState["Models"] as DataTable;
            try
            {
                ddlAssetModel.Items.Clear();
                DataTable filteredDT;
                var result = modelDT.AsEnumerable()
                    .Where(r => r.Field<int>("Make") == index);

                if (Enumerable.Any(result)) { 
                    filteredDT = result.CopyToDataTable();
                    ddlAssetModel.DataSource = filteredDT;
                    ddlAssetModel.DataTextField = "Model";
                    ddlAssetModel.DataValueField = "ModelID";
                    ddlAssetModel.DataBind();
                }
                else
                {
                    ddlAssetModel.Items.Insert(0, new ListItem("No valid models for this make", "Invalid"));
                    ddlAssetModel.DataBind();
                }
            }
            catch(Exception ex)
            {
                //Add error message
            }

            ddlAssetModel.SelectedIndex = 0;
            upMakeModel.Update();
        }

        protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            lblLocationDescriptionText.Text = new GetLocationInfoByID().ExecuteCommand(int.Parse(ddl.SelectedValue)).Rows[0]["LocationDescription"].ToString();
            upLocation.Update();
        }

        protected void ddlAssetStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            DataTable locs = new GetLocationByStatus().ExecuteCommand(ddl.SelectedItem.Text);
            if (locs == null || locs.Rows.Count == 0)
                ddlLocation.Items.Insert(0, new ListItem("No valid locations", "Invalid"));
            ddlLocation.DataSource = locs;
            ddlLocation.DataBind();
            upLocation.Update();
        }
    }
}