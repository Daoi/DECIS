using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Assets
{
    public class FilterAssets : DataSupport, IData
    {
        public FilterAssets()
        {
            CommandText = "FilterAssets";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(string status, string location = null)
        {
            Parameters = new MySqlParameter[2] {
                new MySqlParameter("Status", status),
                new MySqlParameter("Location", location)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}