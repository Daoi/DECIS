using DECIS.DataAccess.DataAccessors.Location;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.Settings
{
    public class SettingsLocation
    {
        public static int Add(Page pg)
        {
            //Find Controls
            TextBox tbLocation = FindControl.Find("tbLocationName", pg) as TextBox;
            TextBox tbLocationDesc = FindControl.Find("tbLocationDesc", pg) as TextBox;
            Label lblLocMsg = FindControl.Find("lblLocMsg", pg) as Label;
            DropDownList ddlLocStatus = FindControl.Find("ddlAssetStatus", pg) as DropDownList;
            UpdatePanel upLocation = FindControl.Find("upLocation", pg) as UpdatePanel;

            try
            {
                int x = new InsertLocation().ExecuteCommand(tbLocation.Text, tbLocationDesc.Text, int.Parse(ddlLocStatus.SelectedValue));
                lblLocMsg.Text = $"Succesfully added new Location: {tbLocation.Text}";
                upLocation.Update();
                return x;

            }
            catch(Exception e)
            {
                lblLocMsg.Text = $"Couldn't add new location, please try again later. {e.Message}";
                upLocation.Update();
                return -1;
            }
        }
    }
}