using DECIS.DataAccess.DataAccessors.Location;
using DECIS.DataAccess.DataAccessors.Make;
using DECIS.DataAccess.DataAccessors.Model;
using DECIS.DataAccess.DataAccessors.Status;
using DECIS.PageLogic;
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
            List<DropDownList> ddls = new List<DropDownList>() { ddlAssetMake, ddlAssetModel, ddlAssetStatus, ddlLocation };
            DDLDataBind.ddlBind(ddls);
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
    }
}