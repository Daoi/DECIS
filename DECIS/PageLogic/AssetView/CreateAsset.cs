using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.PageLogic.AssetView
{
    public class CreateAsset
    {
        AssetPage _pageContainer;
        public CreateAsset(AssetPage pageContainer)
        {
            _pageContainer = pageContainer;
        }

        public Asset Create()
        {
             Asset assetFromPage = new Asset
            {
                AssetID = int.Parse(_pageContainer.hfAssetID.Value),
                SerialNumber = _pageContainer.hfSerialNumber.Value,
                Model = _pageContainer.ddlAssetModel.SelectedItem.ToString(),
                ModelID = int.Parse(_pageContainer.ddlAssetModel.SelectedValue),
                Make = _pageContainer.ddlAssetMake.SelectedItem.ToString(),
                MakeID = int.Parse(_pageContainer.ddlAssetMake.SelectedValue),
                AssetType = _pageContainer.lblAssetTypeText.Text,
                Description = _pageContainer.tbAssetDescription.Text,
                Location = _pageContainer.ddlLocation.SelectedItem.ToString(),
                LocationID = int.Parse(_pageContainer.ddlLocation.SelectedValue),
                LocationDescription = _pageContainer.lblLocationDescriptionText.Text,
                Status = _pageContainer.ddlAssetStatus.SelectedItem.ToString(),
                StatusID = int.Parse(_pageContainer.ddlAssetStatus.SelectedValue),
                Image = _pageContainer.crdAssetImage.Src,
            };

            return assetFromPage;
        }
    }
}