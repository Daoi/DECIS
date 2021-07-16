using DECIS.DataAccess.DataAccessors;
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
                    lblNoRows.Text = "Couldn't find any events to display.";
                    divNoRows.Visible = true;
                    return;
                }
                gvAssetList.DataSource = dtAssetList;
                gvAssetList.DataBind();

                Session["AssetListDT"] = dtAssetList;
            }

            dtAssetList = Session["AssetListDT"] as DataTable;

            if (Request.Browser.IsMobileDevice)
                gvAssetList.Columns[2].Visible = false; //Hide event description on mobile
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Homepage.aspx");
        }
    }
}