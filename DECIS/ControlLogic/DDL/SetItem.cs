using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DECIS.ControlLogic.DDL
{
    public class SetItem
    {
        /// <summary>
        /// Set the selected item of a drop down list control by using a text value
        /// </summary>
        /// <param name="ddlData">the drop down list to use</param>
        /// <param name="value">The text value to look for</param>
        public static void SetItemByText(DropDownList ddlData, string value)
        {
            ddlData.SelectedIndex = ddlData.Items.IndexOf(ddlData.Items.FindByText(value));
        }
    }
}