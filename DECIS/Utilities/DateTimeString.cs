using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.Utilities
{
    public class DateTimeString
    {
        /// <summary>
        /// Format a date string for asp.net textmode textbox
        /// </summary>
        /// <param name="str">The date string</param>
        /// <returns></returns>
        public static string GetDateString(string str)
        {
            DateTime date;

            if (DateTime.TryParse(str, out date))
                return date.ToString("MM-dd-yyyy");
            else
                return "";
        }
    }
}