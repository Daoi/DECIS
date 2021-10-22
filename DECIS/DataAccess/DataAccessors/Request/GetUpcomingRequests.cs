using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class GetUpcomingRequests : DataSupport, IData
    {
        public GetUpcomingRequests()
        {
            CommandText = "GetUpcomingRequests";
            CommandType = CommandType.StoredProcedure;
        }


        public DataTable ExecuteCommand(DateTime start, DateTime end)
        {
            Parameters = new MySqlParameter[2] { new MySqlParameter("StartDate", start), new MySqlParameter("EndDate", end) };
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}