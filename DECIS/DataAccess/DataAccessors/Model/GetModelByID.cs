using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Model
{
    public class GetModelByID : DataSupport, IData
    {
        public GetModelByID()
        {
            CommandText = "GetModelByID";
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