using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Assets
{
    public class GetAllAssetsByStatusWithIntake : DataSupport, IData
    {
        public GetAllAssetsByStatusWithIntake()
        {
            CommandText = "GetAllAssetsByStatusWithIntake";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int statusID)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("Status", statusID) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}