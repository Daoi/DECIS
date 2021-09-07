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
        public static Recycle Create(Page pg)
        {
            Recycle r = new Recycle()
            {
                RecycleReceiver = int.Parse((FindControl.Find("ddlRecycleOrg", pg) as DropDownList).SelectedValue),
                RecycleStatus = int.Parse((FindControl.Find("ddlRecycleStatus", pg) as DropDownList).SelectedValue),
                Date = (FindControl.Find("tbRecycleDate", pg) as TextBox).Text,
                Recycler = (FindControl.Find("tbRecycler", pg) as TextBox).Text,
            };

            return r;
        }
    }
}