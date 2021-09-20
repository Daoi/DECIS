using DECIS.DataAccess.DataAccessors;
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
    public partial class AssetList : System.Web.UI.Page
    {
        DataTable dtAssetList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvAssetList.DataBound += (object o, EventArgs ev) =>
                {
                    gvAssetList.HeaderRow.TableSection = TableRowSection.TableHeader;
                };

                dtAssetList = new GetAllAssets().ExecuteCommand();

                if (dtAssetList.Rows.Count == 0)
                {
                    lblNoRows.Text = "Couldn't find any assets to display.";
                    divNoRows.Visible = true;
                    return;
                }
                gvAssetList.DataSource = dtAssetList;
                gvAssetList.DataBind();

                ViewState["AssetListDT"] = dtAssetList;
            }

            dtAssetList = ViewState["AssetListDT"] as DataTable;

        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Homepage.aspx");
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
    }
}