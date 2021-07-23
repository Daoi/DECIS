using DECIS.DataAccess.DataAccessors.Location;
using DECIS.DataAccess.DataAccessors.Make;
using DECIS.DataAccess.DataAccessors.Model;
using DECIS.DataAccess.DataAccessors.Status;
using DECIS.CotrolLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class AssetForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                RetrieveData();
            }
        }

        private void RetrieveData()
        {


            List<DropDownList> ddls = new List<DropDownList>() { ddlAssetMake, ddlAssetModel, ddlAssetStatus, ddlLocation, ddlAssetType };
            List<DataTable> dts = DDLDataBind.ddlBind(ddls);

            ViewState["Make"] = dts[0];
            ViewState["Models"] = dts[1];
            ViewState["Locations"] = dts[3];
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

        protected void ddlAssetType_DataBound(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            ddl.Items.Insert(0, new ListItem("Select Asset Type", "-1"));
        }

        protected void ddlAssetType_SelectedIndexChanged(object sender, EventArgs e)
        { 
         
            //Use update panel to update display after last line

            DropDownList ddl = sender as DropDownList;
            if (ddl.SelectedIndex == 0)
                return;
            DataTable modelDT = ViewState["Models"] as DataTable;
            DataTable makeDT = ViewState["Make"] as DataTable;
            ddlAssetModel.DataSource = modelDT.AsEnumerable().Where(r => r.Field<int>("AssetType") == ddl.SelectedIndex).CopyToDataTable();
        }
    }
}