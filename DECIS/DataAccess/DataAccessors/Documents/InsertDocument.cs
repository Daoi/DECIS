using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Documents
{
    public class InsertDocument : DataSupport, IData
    {
        public InsertDocument()
        {
            CommandText = "InsertDocuments";
            CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteCommand(string info, int id)
        {


            Parameters = new MySqlParameter[2] {
                new MySqlParameter("OrgID", id),
                new MySqlParameter("AwsInfo", info)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteNonQuery(this); //Run the command
        }
    }
}