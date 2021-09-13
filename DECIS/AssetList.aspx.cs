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
            DataRow dr;
            //Recreate the Datarow the GVR is bound to
            if (ViewState["Filter"] == null)
                dr = (ViewState["AssetListDT"] as DataTable).Rows[row.DataItemIndex];
            else
                dr = (ViewState[$"{ViewState["Filter"].ToString()}"] as DataTable).Rows[row.DataItemIndex];


            Asset asset = new Asset(dr);

            Session["CurrentAsset"] = asset;
            Response.Redirect("./AssetView.aspx");
        }

        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            DataTable result = null;
            int status = 0;
            //Display
            gvAssetList.Visible = true;
            lblGVMessage.Text = "";
            lblGVMessage.Visible = false;
            ViewState["Filter"] = lb.ID;
            //Filter 

                if (lb.ID == lbGoodStatus.ID)
                    status = 1;
                else if (lb.ID == lbBad.ID)
                    status = 2;
                else if (lb.ID == lbTestingStatus.ID)
                    status = 3;
                else if (lb.ID == lbStorage.ID)
                    status = 4;
                else if (lb.ID == lbDonated.ID)
                    status = 5;
                else if (lb.ID == lbRecycled.ID)
                    status = 6;
                else if (lb.ID == lbNewItems.ID)
                    status = 7;

            if (ViewState[$"{lb.ID}"] == null)
                {
                    ViewState[$"{lb.ID}"] = new GetAllAssetsByStatusWithIntake().ExecuteCommand(status);
                    result = ViewState[$"{lb.ID}"] as DataTable;
                }
                else
                    result = ViewState[$"{lb.ID}"] as DataTable;

                gvAssetList.DataSource = result;
                gvAssetList.DataBind();
            

            if (result == null || result.Rows.Count == 0)
            {
                lblGVMessage.Visible = true;
                lblGVMessage.Text = $"Couldn't find any requests with status {lb.Text}";
                gvAssetList.Visible = false;
            }
        }

        protected void lbAllAssets_Click(object sender, EventArgs e)
        {
            lblGVMessage.Visible = false;
            gvAssetList.Visible = true;
            ViewState["FilterStatus"] = null;
            gvAssetList.DataSource = ViewState["AssetListDT"] as DataTable;
            gvAssetList.DataBind();
            pnlFilters.Controls.OfType<LinkButton>().ToList().ForEach(c => c.Visible = true);
            upLocationDDL.Update();
        }

    }
}