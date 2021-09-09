using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.Utilities
{
    public class DateTimeString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="tb">If true returns yyyy-MM-dd format for textboxes, otherwise MM-dd-yyyy</param>
        /// <returns></returns>
        public static string GetDateString(string str, bool tb = false)
        {
            DateTime date;

            if (DateTime.TryParse(str, out date))
                if (tb)
                    return date.ToString("yyyy-MM-dd");
                else
                    return date.ToString("MM-dd-yyyy");
            else
                return "";
        }


    }
}