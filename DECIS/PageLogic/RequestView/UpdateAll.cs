using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace DECIS.PageLogic.RequestView
{
    public class UpdateAll
    {
        public static void Update(Page pg)
        {
            (FindControl.Find("upComputers", pg) as UpdatePanel).Update();
            (FindControl.Find("upAssigned", pg) as UpdatePanel).Update();
        }
    }
}