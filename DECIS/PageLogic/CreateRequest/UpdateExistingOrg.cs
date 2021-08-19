using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.CreateRequest
{
    public class UpdateExistingOrg
    {
        public static void Update(Page pg, Organization org)
        {
            org.Purpose = (FindControl.FindNM("tbOrgPurpose", pg) as TextBox).Text;
            org.Referer = (FindControl.FindNM("tbReferer", pg) as TextBox).Text;
            org.ReceivedEquipment = (FindControl.FindNM("ddlReceivedEquipment", pg) as DropDownList).SelectedValue == "1";
        }
    }
}