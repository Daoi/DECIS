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

        public DataTable ExecuteCommand(Asset ast)
        {
            string sn = ast.SerialNumber;
            string desc = ast.Description;
            int intakeid = ast.IntakeID;

            Parameters = new MySqlParameter[3] {
                new MySqlParameter("SerialNumber", sn),
                new MySqlParameter("Description", desc),
                new MySqlParameter("IntakeID", intakeid)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}