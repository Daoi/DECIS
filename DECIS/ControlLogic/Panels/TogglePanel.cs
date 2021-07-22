using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.ControlLogic.Panels
{
    public class TogglePanel
    {
        /// <summary>
        /// Toggle the enabled state of all input controls(TextBox/DDL) on a panel, optionally controls inside an update panel as well.
        /// </summary>
        /// <param name="pnl">The panel to toggle controls for</param>
        /// <param name="up">Flag for whether to search update panels as well</param>
        public static void ToggleInputs(Panel pnl, bool up = false)
        {
            pnl.Controls.OfType<TextBox>().ToList().ForEach(tb => tb.Enabled = !tb.Enabled);
            pnl.Controls.OfType<DropDownList>().ToList().ForEach(ddl => ddl.Enabled = !ddl.Enabled);
            //Controls nested in update panel
            if (up)
            {
                pnl.Controls.OfType<UpdatePanel>().ToList().ForEach(u => u.ContentTemplateContainer.Controls.OfType<DropDownList>().ToList().ForEach(ddl => ddl.Enabled = !ddl.Enabled));
                pnl.Controls.OfType<UpdatePanel>().ToList().ForEach(u => u.ContentTemplateContainer.Controls.OfType<TextBox>().ToList().ForEach(tb => tb.Enabled = !tb.Enabled));
            }
            //Using the panel itself affects display too much. Better to do controls in panel.
        }
    }
}