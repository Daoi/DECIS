using DECIS.ControlLogic.Gridview;
using DECIS.DataAccess.DataAccessors;
using DECIS.DataAccess.DataAccessors.Assets;
using DECIS.DataAccess.DataAccessors.Location;
using DECIS.DataModels;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class AssetList : System.Web.UI.Page
    {
        DataTable dtAssetList;

        protected void Page_Load(object sender, EventArgs e)
        {
            HeaderBinding.CreateHeaders(gvAssetList);
            if (!IsPostBack)
            {
                dtAssetList = new GetAllAssets().ExecuteCommand();

                if (dtAssetList.Rows.Count == 0)
                {
                    lblGVMessage.Text = "Couldn't find any assets to display.";
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

        protected void lb_Click(object sender, EventArgs e)
        {
            lblGVMessage.Visible = false;
            LinkButton lb = (LinkButton)sender;
            string status = lb.Text;
            ViewState["CurrentStatus"] = status;

            DataTable filtered = new FilterAssets().ExecuteCommand(status);
            if (filtered.Rows.Count == 0)
            {
                lblGVMessage.Text = "No matching items found";
                lblGVMessage.Visible = true;
            }
            gvAssetList.DataSource = filtered;
            gvAssetList.DataBind();
            ViewState["FilterStatus"] = lb.Text;

            DataTable locs = new GetLocationByStatus().ExecuteCommand(status);

            ddlLocationFilter.DataSource = locs;
            ddlLocationFilter.DataTextField = "Location";
            ddlLocationFilter.DataValueField = "Location";
            ddlLocationFilter.DataBind();
            ddlLocationFilter.Visible = true;
            pnlFilters.Controls.OfType<LinkButton>().Where(c => c != lb).ToList().ForEach(c => c.Visible = false);
            lbAllAssets.Visible = true;
            upLocationDDL.Update();

        }

        protected void lbAllAssets_Click(object sender, EventArgs e)
        {
            lblGVMessage.Visible = false;
            ViewState["FilterStatus"] = null;
            gvAssetList.DataSource = ViewState["AssetListDT"] as DataTable;
            gvAssetList.DataBind();
            pnlFilters.Controls.OfType<LinkButton>().ToList().ForEach(c => c.Visible = true);
            ddlLocationFilter.Visible = false;
            upLocationDDL.Update();
        }

        protected void ddlLocationFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblGVMessage.Visible = false;

            string status = ViewState["FilterStatus"].ToString() ?? "%";
            DataTable filtered = new FilterAssets().ExecuteCommand(status, ddlLocationFilter.SelectedItem.Text);
            gvAssetList.DataSource = filtered;
            gvAssetList.DataBind();

            if (filtered.Rows.Count == 0)
            {
                lblGVMessage.Text = "No matching items found";
                lblGVMessage.Visible = true;
            }

            upLocationDDL.Update();

        }

        protected void ddlLocationFilter_DataBound(object sender, EventArgs e)
        {
            try
            {
                ddlLocationFilter.SelectedValue = "-1";
                ddlLocationFilter.Items.RemoveAt(ddlLocationFilter.SelectedIndex);
                ddlLocationFilter.Items.Insert(0, new ListItem("Select Location", "-1"));
            }
            catch (Exception ex)
            {
                ddlLocationFilter.Items.Insert(0, new ListItem("Select Location", "-1"));
            }

        }
    }
}