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
        public static bool Display(Page pg, Asset curAsset)
        {
            try
            {
                //Setup asset info display
                (FindControl.Find("crdAssetImage", pg) as HtmlImage).Src = curAsset.Image;
                (FindControl.Find("lblSerialNumber", pg) as Label).Text = $"Serial Number: {curAsset.SerialNumber} | Asset ID: {curAsset.AssetID} | Intake ID(s): {string.Join(",", curAsset.IntakeID)}";
                (FindControl.Find("tbAssetDescription", pg) as TextBox).Text = curAsset.Description;
                (FindControl.Find("lblAssetTypeText", pg) as Label).Text = curAsset.AssetType;
                (FindControl.Find("lblLocationDescriptionText", pg) as Label).Text = curAsset.LocationDescription;
                SetItem.SetItemByText(FindControl.Find("ddlAssetMake", pg) as DropDownList, curAsset.Make);
                SetItem.SetItemByText(FindControl.Find("ddlAssetModel", pg) as DropDownList, curAsset.Model);
                SetItem.SetItemByText(FindControl.Find("ddlAssetStatus", pg) as DropDownList, curAsset.Status);
                SetItem.SetItemByText(FindControl.Find("ddlLocation", pg) as DropDownList, curAsset.Location);
                //Disable on page first load(Not in edit mode yet)
                TogglePanel.ToggleInputs(FindControl.Find("pnlControls", pg) as Panel, true);
                //Hide edit button on uneditable assets
                if (curAsset.StatusID == 5 || curAsset.StatusID == 6)
                    (FindControl.Find("btnEdit", pg) as Button).Visible = false;
                return true;
            }
            catch(NullReferenceException ex)
            {
                throw new NullReferenceException($"{ex.Message} + Control not found");
            }
        }
    }
}