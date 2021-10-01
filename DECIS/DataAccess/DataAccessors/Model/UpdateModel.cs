using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Model
{
    public class UpdateModel : DataSupport, IData
    {
        public UpdateModel()
        {
            CommandText = "UpdateModel";
            CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteCommand(DataModels.Model mdl)
        {
            Parameters = new MySqlParameter[5] {
                new MySqlParameter("ModelID", mdl.ModelID),
                new MySqlParameter("Model", mdl.ModelName),
                new MySqlParameter("Make", mdl.MakeID),
                new MySqlParameter("Image", mdl.Image),
                new MySqlParameter("AssetType", mdl.AssetTypeID)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteNonQuery(this); //Run the command
        }
    }
}