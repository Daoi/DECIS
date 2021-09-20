using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Recycle
{
    public class GetRecycleByID : DataSupport, IData
    {
        public GetRecycleByID()
        {
            CommandText = "GetRecycleByID";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int id)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("RecycleID", id) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}