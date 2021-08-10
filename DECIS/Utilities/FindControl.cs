using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace DECIS.Utilities
{
    public class FindControl
    {
        /// <summary>
        /// Find a control on a page from class
        /// Page = Page to search
        /// str = Control ID
        /// Returns generic Control (Cast to proper control)
        /// </summary>
        public static Func<string, Page, Control> Find = (str, pg) => pg.Master.FindControl("MainContent").FindControl(str);
    }
}