using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.Settings
{
    public class SettingsClearLabels
    {
        public static void Clear(Page pg)
        {
            (FindControl.Find("lblModelMsg", pg) as Label).Text = "";
            (FindControl.Find("lblMakeMsg", pg) as Label).Text = "";
            (FindControl.Find("lblLocMsg", pg) as Label).Text = "";
        }
    }
}