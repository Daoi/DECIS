using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Account
{
    public class GetAccount : DataSupport, IData
    {
        public GetAccount()
        {
            CommandText = "GetAccount";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(string email)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("Email", email) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}