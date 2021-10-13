using DECIS.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.AssetView
{
    /// <summary>
    /// Class to access controls that are modifiable outside the page, pass the instance of this class instead of the entire page
    /// </summary>
    public class AssetPage
    {
        private Page pg;
        //Label props
        public Label lblSerialNumber { get => _lblSerialNumber; }
        public Label lblAssetTypeText { get => _lblAssetTypeText; }
        public Label lblAssetStatus { get => _lblAssetStatus; }
        public Label lblAssetMake { get => _lblAssetMake; }
        public Label lblAssetModel { get => _lblAssetModel; }
        public Label lblLocation { get => _lblLocation; }
        public Label lblLocationDescription { get => _lblLocationDescription; }
        public Label lblLocationDescriptionText { get => _lblLocationDescriptionText; }
        public Label lblAssetDescription { get => _lblAssetDescription; }
        //Button props
        public Button btnEdit { get => _btnEdit; }
        public Button btnCancelEdit { get => _btnCancelEdit; }
        public Button btnViewIntake { get => _btnViewIntake; }
        //Panel props
        public UpdatePanel upMakeModel { get => _upMakeModel; }
        public Panel pnlControls { get => _pnlControls; }
        //Textbox props
        public TextBox tbAssetDescription { get => _tbAssetDescription; }
        //DDL props
        public DropDownList ddlAssetStatus { get => _ddlAssetStatus; }
        public DropDownList ddlAssetMake { get => _ddlAssetMake; }
        public DropDownList ddlAssetModel { get => _ddlAssetModel; }
        public DropDownList ddlLocation { get => _ddlAssetModel; }
        //Hidden Field props
        public HiddenField hfAssetID { get => _hfAssetID; }
        public HiddenField hfSerialNumber { get => _hfSerialNumber; }
        //Images
        public HtmlImage crdAssetImage { get => _crdAssetImage; }


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
        UpdatePanel _upMakeModel;
        Panel _pnlControls;
        //DropdownList
        DropDownList _ddlAssetStatus;
        DropDownList _ddlAssetMake;
        DropDownList _ddlAssetModel;
        DropDownList _ddlLocation;
        //Textbox
        TextBox _tbAssetDescription;
        //HiddenField
        HiddenField _hfAssetID;
        HiddenField _hfSerialNumber;
        //HTML Image
        HtmlImage _crdAssetImage;

        //Lists
        public List<TextBox> TextBox { get; }
        public List<Button> Button { get; }
        public List<Label> Label { get; }
        public List<DropDownList> DropDownList { get; }


        /// <summary>
        /// Access controls from a speific page externally
        /// </summary>
        /// <param name="pg">The Asset View Page</param>
        public AssetPage(Page pg)
        {
            if (pg.Title != "Asset View")
                throw new ArgumentException("Page must be an instance of AssetView.aspx");

            TextBox = new List<TextBox>();
            Button = new List<Button>();
            Label = new List<Label>();
            DropDownList = new List<DropDownList>();

            this.pg = pg;
            InitializeControls();
        }

        private void InitializeControls()
        {
            var fieldArray = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            for (int i = 0; i < fieldArray.Length; i++)
            {
                //Try to find a control matching the property name
                var control = FindControl.Find($"{fieldArray[i].Name.Replace("_", "")}", pg);
                if (control == null)
                    continue; //Can't find the control, just skip, might not be visible/rendered yet

                Type fieldType = fieldArray[i].FieldType;
                IList list = GetType().GetProperty(fieldType.Name, BindingFlags.Instance)?.GetValue(this) as IList;
                list?.Add(control);
                fieldArray[i].SetValue(this, Convert.ChangeType(control, fieldType));
            }
        }
    }
}