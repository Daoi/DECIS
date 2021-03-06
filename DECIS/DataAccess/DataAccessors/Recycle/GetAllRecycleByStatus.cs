using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Recycle
{
    public class GetAllRecycleByStatus : DataSupport, IData
    {
        public GetAllRecycleByStatus()
        {
            CommandText = "GetAllRecycleByStatus";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int status)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("RecycleStatus", status) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}