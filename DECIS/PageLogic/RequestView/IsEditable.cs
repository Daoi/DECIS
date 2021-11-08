using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.PageLogic.RequestView
{
    public class IsEditable
    {
        /// <summary>
        /// Check if a request is editable based on status
        /// </summary>
        /// <param name="status">The integer status</param>
        /// <returns>If true it's editable, otherwise its finished or cancelled</returns>
        public static bool Check(int status)
        {
            return !(status == 4 || status == 5);
        }
    }
}