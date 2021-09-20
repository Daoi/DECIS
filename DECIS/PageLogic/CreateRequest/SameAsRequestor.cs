using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.CreateRequest
{
    public class SameAsRequestor
    {
        /// <summary>
        /// Is the contact information the same as the requestors information?
        /// </summary>
        public static void Fill(CheckBox cb, Page pg)
        {
            if (cb.Checked)
            {
                (FindControl.FindNM("tbContactName", pg) as TextBox).Text = (FindControl.FindNM("tbName", pg) as TextBox).Text;
                (FindControl.FindNM("tbContactEmail", pg) as TextBox).Text = (FindControl.FindNM("tbEmail", pg) as TextBox).Text;
                (FindControl.FindNM("tbContactPhone", pg) as TextBox).Text = (FindControl.FindNM("tbPhone", pg) as TextBox).Text;

            }
            else
            {
                (FindControl.FindNM("tbContactName", pg) as TextBox).Text = "";
                (FindControl.FindNM("tbContactEmail", pg) as TextBox).Text = "";
                (FindControl.FindNM("tbContactPhone", pg) as TextBox).Text = "";
            }

        }

    }
}