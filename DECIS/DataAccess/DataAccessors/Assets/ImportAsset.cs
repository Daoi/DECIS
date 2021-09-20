using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using DECIS.DataModels;

namespace DECIS.DataAccess.DataAccessors.Assets
{
    public class ImportAsset : DataSupport, IData
    {
        public ImportAsset()
        {
            CommandText = "ImportAsset";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(Asset ast, int intakeID)
        {
            Parameters = new MySqlParameter[4] {
                new MySqlParameter("SerialNumber", ast.SerialNumber),
                new MySqlParameter("Description", ast.Description),
                new MySqlParameter("IntakeID", intakeID),
                new MySqlParameter("Model", ast.ModelID),
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}