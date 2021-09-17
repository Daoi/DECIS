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
    public class CreateRecycle
    {
        public static Recycle Create(Page pg, int rcID)
        {
            Recycle r = new Recycle()
            {
                RecycleID = rcID,
                RecycleReceiver = int.Parse((FindControl.Find("ddlRecycleOrg", pg) as DropDownList).SelectedValue),
                RecycleStatus = int.Parse((FindControl.Find("ddlRecycleStatus", pg) as DropDownList).SelectedValue),
                Date = (FindControl.Find("tbRecycleDate", pg) as TextBox).Text,
            };

            return r;
        }
    }
}