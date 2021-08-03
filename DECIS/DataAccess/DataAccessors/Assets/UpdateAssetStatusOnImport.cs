using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DECIS.DataModels;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Assets
{
    public class UpdateAssetStatusOnImport : DataSupport, IData
    {
        public UpdateAssetStatusOnImport()
        {
            CommandText = "UpdateAssetStatusOnImport";
            CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteCommand(int astID, int intID)
        {

            Parameters = new MySqlParameter[2] {
                new MySqlParameter("AssetID", astID),
                new MySqlParameter("IntakeID", intID)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteNonQuery(this); //Run the command
        }
    }
}