using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.RecycleView
{
    public class Display
    {
        public static void DisplayRecycle(Page pg, Recycle r)
        {
            (FindControl.Find("ddlRecycleOrg", pg) as DropDownList).SelectedValue = r.RecycleReceiver.ToString();
            (FindControl.Find("ddlRecycleStatus", pg) as DropDownList).SelectedValue = r.RecycleStatus.ToString();
            (FindControl.Find("tbRecycleDate", pg) as TextBox).Text = DateTimeString.GetDateString(r.Date);
            (FindControl.Find("tbRecycler", pg) as TextBox).Text = r.Recycler;
        }
    }
}