using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.ControlLogic.Gridview
{
    public class BoundFieldFormatter
    {
        public static string FormatDates(object value)
        {
            try
            {
                return DateTime.Parse(value.ToString()).ToString("MM-dd-yyyy");
            }
            catch (Exception e)
            {
                return "Invalid value";
            }
        }
        /// <summary>
        /// Avoid empty values
        /// </summary>
        /// <returns></returns>
        public static string FormatGeneric(object value)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                    return "No Value";
                else
                    return value.ToString();
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public static string FormatLongText(object value)
        {
            if (value.ToString().Length >= 110)
            {
                try
                {
                    return value.ToString().Substring(0, 100) + "...";
                }
                catch (Exception e)
                {
                    return value.ToString();
                }
            }
            else
            {
                return value.ToString();
            }
        }
    }
}