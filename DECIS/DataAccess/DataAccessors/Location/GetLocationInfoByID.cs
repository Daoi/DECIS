using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Location
{
    public class GetLocationInfoByID : DataSupport, IData
    {
        public GetLocationInfoByID()
        {
            CommandText = "GetLocationInfoByID";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int locationID)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("LocationID", locationID) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}