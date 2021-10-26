using DECIS.ControlLogic.DDL;
using DECIS.ControlLogic.Panels;
using DECIS.DataModels;
using DECIS.PageLogic.AssetView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DECIS.PageLogic.ControlContainerBase;

namespace DECIS.PageLogic.DisplayStrategy
{
    public class AssetDisplayStrategy : IDisplayStrategy
    {

        public AssetDisplayStrategy()
        {
        }


        public bool Display(ControlContainer controlContainer, object dataModel)
        {
            try
            {
                Asset _dataModel = (Asset)dataModel;
                AssetPage _controlContainer = (AssetPage)controlContainer;
                //Setup asset info display
                _controlContainer.crdAssetImage.Src = _dataModel.Image;
                _controlContainer.lblSerialNumber.Text = $"Serial Number: {_dataModel.SerialNumber} | Asset ID: {_dataModel.AssetID} | Intake ID(s): {string.Join(",", _dataModel.IntakeID)}";
                _controlContainer.tbAssetDescription.Text = _dataModel.Description;
                _controlContainer.lblAssetTypeText.Text = _dataModel.AssetType;
                _controlContainer.lblLocationDescriptionText.Text = _dataModel.LocationDescription;
                SetItem.SetItemByText(_controlContainer.ddlAssetMake, _dataModel.Make);
                SetItem.SetItemByText(_controlContainer.ddlAssetModel, _dataModel.Model);
                SetItem.SetItemByText(_controlContainer.ddlAssetStatus, _dataModel.Status);
                SetItem.SetItemByText(_controlContainer.ddlLocation, _dataModel.Location);
                //Disable on page first load(Not in edit mode yet)
                TogglePanel.ToggleInputs(_controlContainer.pnlControls, true);
                //Hide edit button on uneditable assets
                if (_dataModel.StatusID == 5 || _dataModel.StatusID == 6)
                    _controlContainer.btnEdit.Visible = false;
                return true;
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException($"{ex.Message} + Control not found?");
            }
        }
    }
}