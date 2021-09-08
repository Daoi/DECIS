using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.ControlLogic.Panels
{
    public class ClearPanel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnls"></param>
        /// <param name="up">Applies to all panels</param>
        public static void ClearTBs(List<Panel> pnls, bool up = false)
        {
            foreach (Panel pnl in pnls)
            {
                pnl.Controls.OfType<TextBox>().ToList().ForEach(tb => tb.Text = "");
                //Controls nested in update panel
                if (up)
                {
                    try
                    {
                        pnl.Controls.OfType<UpdatePanel>()
                            .ToList()
                            .ForEach(u => u.ContentTemplateContainer
                            .Controls.OfType<TextBox>()
                            .ToList()
                            .ForEach(tb => tb.Text = ""));
                    }
                    catch(Exception ex)
                    {
                        continue;  
                    }
                }
            }
        }
    }
}