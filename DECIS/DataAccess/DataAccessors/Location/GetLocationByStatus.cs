using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Location
{
    public class GetLocationByStatus : DataSupport, IData
    {
        public GetLocationByStatus()
        {
            CommandText = "GetLocationByStatus";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(string status)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("Status", status) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}