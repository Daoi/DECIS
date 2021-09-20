using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Account
{
    public class InsertAccount : DataSupport, IData
    {
        public InsertAccount()
        {
            CommandText = "InsertAccount";
            CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteCommand(string email, string first, string last, int role)
        {

            Parameters = new MySqlParameter[4] {
                new MySqlParameter("Email", email),
                new MySqlParameter("FirstName", first),
                new MySqlParameter("LastName", last),
                new MySqlParameter("Role", role)
            };
            ExecuteQuery eq = new ExecuteQuery(); 
            return eq.ExecuteNonQuery(this); 
        }
    }
}