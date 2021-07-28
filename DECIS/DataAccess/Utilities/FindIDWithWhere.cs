using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DECIS.DataAccess.Utilities
{
    public class FindIDWithWhere
    {
        /// <summary>
        /// Compare two data sources to find an ID by comparing values of columns
        /// </summary>
        /// <param name="dt">Datatable(Look up table) from the database</param>
        /// <param name="dr">Datarow from the spreadsheet</param>
        /// <param name="valueColumn">The columns to compare</param>
        /// <param name="idColumn">The column in the datatable to look for the ID in</param>
        /// <returns>the ID of the value from the database or -1 if no match</returns>
        public static int FindID(DataTable dt, DataRow dr, string valueColumn, string idColumn)
        {
            DataRow match = dt.AsEnumerable().FirstOrDefault
                     (r => r.Field<string>(valueColumn).ToLower() == dr[valueColumn].ToString().Trim().ToLower());

            if (match != null)
                return match.Field<int>(idColumn);
            else
                return -1;
        }
        /// <summary>
        /// Compare two data sources to find an ID by comparing values of columns
        /// </summary>
        /// <param name="dt">Datatable from the db</param>
        /// <param name="dr">Datarow to compare with table</param>
        /// <param name="dtValueColumn">Name of the column in the DT with the value</param>
        /// <param name="drValueColumn">Name of the column in the DR with the value</param>
        /// <param name="idColumn">The ID column</param>
        /// <returns>The id of a match or -1</returns>
        public static int FindID(DataTable dt, DataRow dr, string dtValueColumn, string drValueColumn, string idColumn)
        {
            DataRow match = dt.AsEnumerable().FirstOrDefault
                     (r => r.Field<string>(dtValueColumn).ToLower() == dr[drValueColumn].ToString().Trim().ToLower());

            if (match != null)
                return match.Field<int>(idColumn);
            else
                return -1;
        }
    }
}