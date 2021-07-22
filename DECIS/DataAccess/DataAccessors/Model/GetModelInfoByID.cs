using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Model
{
    public class GetModelInfoByID : DataSupport, IData
    {
        public GetModelInfoByID()
        {
            CommandText = "GetModelInfoByID";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int modelID)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("ModelID", modelID) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}