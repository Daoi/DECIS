using DECIS.DataAccess.DataAccessors.Make;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.Settings
{
    public class SettingsMake
    {

        public static int Add(Page pg)
        {
            //Find Controls
            TextBox tbMake = FindControl.Find("tbMake", pg) as TextBox;
            Label lblMakeMsg = FindControl.Find("lblMakeMsg", pg) as Label;
            UpdatePanel upMake = FindControl.Find("upMake", pg) as UpdatePanel;

            try
            {
                int res = new InsertMake().ExecuteCommand(tbMake.Text);
                lblMakeMsg.Text = $"Succesfully added Make: {tbMake.Text}";
                upMake.Update();
                return res;
            }
            catch (Exception ex)
            {
                lblMakeMsg.Text = $"Couldn't succesfully add Make, try again later";
                lblMakeMsg.Visible = true;
                upMake.Update();
                return -1;

            }
        }
    }
}