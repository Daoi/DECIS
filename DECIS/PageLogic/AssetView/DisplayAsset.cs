using DECIS.ControlLogic.DDL;
using DECIS.ControlLogic.Panels;
using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.AssetView
{
    public class DisplayAsset
    {
        public static bool Display(AssetPage pageContainer, Asset curAsset)
        {
            try
            {
                //Setup asset info display
                pageContainer.crdAssetImage.Src = curAsset.Image;
                pageContainer.lblSerialNumber.Text = $"Serial Number: {curAsset.SerialNumber} | Asset ID: {curAsset.AssetID} | Intake ID(s): {string.Join(",", curAsset.IntakeID)}";
                pageContainer.tbAssetDescription.Text = curAsset.Description;
                pageContainer.lblAssetTypeText.Text = curAsset.AssetType;
                pageContainer.lblLocationDescriptionText.Text = curAsset.LocationDescription;
                SetItem.SetItemByText(pageContainer.ddlAssetMake, curAsset.Make);
                SetItem.SetItemByText(pageContainer.ddlAssetModel, curAsset.Model);
                SetItem.SetItemByText(pageContainer.ddlAssetStatus, curAsset.Status);
                SetItem.SetItemByText(pageContainer.ddlLocation, curAsset.Location);
                //Disable on page first load(Not in edit mode yet)
                TogglePanel.ToggleInputs(pageContainer.pnlControls, true);
                //Hide edit button on uneditable assets
                if (curAsset.StatusID == 5 || curAsset.StatusID == 6)
                    pageContainer.btnEdit.Visible = false;
                return true;
            }
            catch(NullReferenceException ex)
            {
                throw new NullReferenceException($"{ex.Message} + Control not found");
            }
        }
    }
}