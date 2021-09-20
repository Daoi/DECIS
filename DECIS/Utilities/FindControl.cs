using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        /// <summary>
        /// Find a control on a page without a master page
        /// </summary>
        public static Func<string, Page, Control> FindNM = (str, pg) => pg.FindControl(str);
        public static Func<string, Panel, Control> FindInPanel = (str, pnl) => pnl.FindControl(str);


        public static Control FindInPanels(string id, List<Panel> panels)
        {
            Control c;
            foreach(Panel pnl in panels)
            {
                if (pnl.Visible == false)
                    continue;

                c = pnl.FindControl(id);
                if (c != null)
                    return c;
            }
            return null;
        }

    }
}