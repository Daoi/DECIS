using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.Settings
{
    public class SettingsPage : ControlContainerBase.ControlContainer
    {
            private Page page;
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
            /// <param name="page">The Settings Page</param>
            public SettingsPage(Page page) : base(page)
            {
                if (page.Title != "Settings")
                    throw new ArgumentException("Page must be an instance of Settings.aspx");

                InitializeControls();
            }

            //Todo - Update function to gather controls that are null in cases where they're not rendered on first pass
            //Use linq where to get properties where value = null and then retry searching for those
    }
}