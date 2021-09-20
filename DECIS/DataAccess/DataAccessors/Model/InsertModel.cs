using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Model
{
    public class InsertModel : DataSupport, IData
    {
        public InsertModel()
        {
            CommandText = "InsertModel";
            CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteCommand(DataModels.Model mdl)
        {


            Parameters = new MySqlParameter[4] {
                new MySqlParameter("Model", mdl.ModelName),
                new MySqlParameter("MakeID", mdl.MakeID),
                new MySqlParameter("Image", mdl.Image),
                new MySqlParameter("AssetTypeID", mdl.AssetTypeID)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteNonQuery(this); //Run the command
        }
    }
}