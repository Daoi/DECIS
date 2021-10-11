using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.AssetView
{

    public class AssetPage
    {
        public Label lblSerialNumber { get => _lblSerialNumber; }
        public Label lblAssetTypeText { get => _lblAssetTypeText; }
        public Label lblAssetStatus { get => _lblAssetStatus; }
        public Label lblAssetMake { get => _lblAssetMake; }
        public Label lblAssetModel { get => _lblAssetModel; }
        public Label lblLocation { get => _lblLocation; }
        public Label lblLocationDescription { get => _lblLocationDescription; }
        public Label lblLocationDescriptionText { get => _lblLocationDescriptionText; }
        public Label lblAssetDescription { get => _lblAssetDescription; }
        public Button btnEdit { get => _btnEdit; }
        public Button btnCancelEdit { get => _btnCancelEdit; }
        public Button btnViewIntake { get => _btnViewIntake; }

        //Labels
        Label _lblSerialNumber;
        Label _lblAssetTypeText;
        Label _lblAssetStatus;
        Label _lblAssetMake;
        Label _lblAssetModel;
        Label _lblLocation;
        Label _lblLocationDescription;
        Label _lblLocationDescriptionText;
        Label _lblAssetDescription;
        //Buttons
        Button _btnEdit;
        Button _btnCancelEdit;
        Button _btnViewIntake;
        //Panel

        //DropdownList

        public AssetPage(Page pg)
        {
            if (pg.Title != "Asset View")
                throw new ArgumentException("Page must be an instance of AssetView.aspx");
            var fieldArray = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            for(int i = 0; i< fieldArray.Length; i++)
            {
                Type fieldType = fieldArray[i].FieldType;
                fieldArray[i].SetValue(this, Convert.ChangeType(FindControl.Find($"{fieldArray[i].Name.Replace("_", "")}", pg), fieldType));
            }
        }
    }
}