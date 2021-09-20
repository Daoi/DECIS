using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Person
{
    public class GetPersonByID : DataSupport, IData
    {
        public GetPersonByID()
        {
            CommandText = "GetPersonByID";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int id)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("PersonID", id) };
            ExecuteQuery eq = new ExecuteQuery(); 
            return eq.ExecuteAdapter(this);
        }
    }
}