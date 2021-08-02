using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Assets
{
    public class GetAssetsByIntake : DataSupport, IData
    {
        public GetAssetsByIntake()
        {
            CommandText = "GetAssetsByIntake";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int intakeID)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("IntakeID", intakeID) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}