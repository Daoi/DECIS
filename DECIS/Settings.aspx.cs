using DECIS.CotrolLogic;
using DECIS.DataAccess.DataAccessors.Assets.Types;
using DECIS.DataAccess.DataAccessors.Make;
using DECIS.DataAccess.DataAccessors.Model;
using DECIS.DataModels;
using DECIS.Importing;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DECIS.PageLogic;
using DECIS.PageLogic.Settings;

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
                List<DropDownList> ddls = new List<DropDownList>() { ddlAssetType, ddlAssetMake, ddlLocStatus };
                DataSet dts = DDLDataBind.ddlBind(ddls);
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