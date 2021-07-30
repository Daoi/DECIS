using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DECIS.ControlLogic.Gridview
{
    public class HeaderBinding
    {
        /// <summary>
        /// Creates headers on Gridview binding allowing DataTables js library to attach properly.
        /// </summary>
        /// <param name="gv">The GV to use.</param>
        public static void CreateHeaders(GridView gv)
        {
            gv.DataBound += (object o, EventArgs ev) =>
            {
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            };
        }

        public static void CreateHeaders(List<GridView> gvs)
        {
            foreach (GridView gv in gvs)
            {
                gv.DataBound += (object o, EventArgs ev) =>
                {
                    gv.HeaderRow.TableSection = TableRowSection.TableHeader;
                };
            }
        }
    }
}