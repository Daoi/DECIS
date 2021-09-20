using DECIS.CotrolLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using DECIS.PageLogic.Settings;
using DECIS.CotrolLogic.DDL;

namespace DECIS
{
    public partial class Settings : Page
    {
        //Holds the event handlers
        private static Dictionary<string, Func<Page, int>> eh = new Dictionary<string, Func<Page, int>>()
        {   { "btnAddModel", SettingsModel.Add},
            { "btnAddMake", SettingsMake.Add},
            { "btnAddLocation", SettingsLocation.Add}
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DropDownList> ddls = new List<DropDownList>() { ddlAssetType, ddlAssetMake, ddlAssetStatus };
                DataSet dts = DDLDataBind.Bind(ddls);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SettingsClearLabels.Clear(Page);
            Button btn = (Button)sender;
            int result = eh[btn.ID].Invoke(Page); //Chooses which event handler to run based on control ID
        }


    }
}