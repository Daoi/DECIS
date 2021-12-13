using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Reports
{
    public class GetPersonalRequestReport : DataSupport, IData
    {
        public GetPersonalRequestReport()
        {
            CommandText = "GetPersonalRequestReport";
            CommandType = CommandType.StoredProcedure;
        }
        /// <summary>
        /// Get a personal request report
        /// </summary>
        /// <param name="start">start date</param>
        /// <param name="end">end date</param>
        /// <returns></returns>
        public DataTable ExecuteCommand(DateTime start, DateTime end)
        {
            Parameters = new MySqlParameter[2] { new MySqlParameter("StartDate", start.ToString("yyyy-MM-dd")), new MySqlParameter("EndDate", end.ToString("yyyy-MM-dd")) };
            ExecuteQuery eq = new ExecuteQuery(); 
            return eq.ExecuteAdapter(this); 
        }
    }
}
