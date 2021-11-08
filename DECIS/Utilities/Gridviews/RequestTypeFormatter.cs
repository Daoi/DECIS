using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.Utilities.Gridviews
{
    public class RequestTypeFormatter
    {
        private const string PERSONAL = "1";

        /// <summary>
        /// Get the text value for a request type int
        /// </summary>
        /// <param name="value">the associated text</param>
        /// <returns></returns>
        public static string GetText(string value)
        {
            return value == PERSONAL ? "Personal" : "Organization";
        }
    }
}