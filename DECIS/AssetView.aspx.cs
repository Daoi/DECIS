using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                FormatCard();
            }

        }

        private void FormatCard()
        {
            crdAssetImage.Src = curAsset.Image;
            lblSerialNumber.Text = $" Asset Type: {curAsset.AssetType} | Serial Number: {curAsset.SerialNumber} | Asset ID: {curAsset.AssetID}";
            lblAssetDescription.Text = $"Status: {curAsset.Status} </br>" +
                $"                       Make: {curAsset.Make} </br>" +
                $"                       Model: {curAsset.Model} </br>" +
                $"                       Description: {curAsset.Description} </br>" +
                $"                       Location: {curAsset.Location} </br>" +
                $"                       Location  Description: {curAsset.LocationDescription} </br>";
        }

    }
}