using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Organization
{
    public class InsertOrg : DataSupport, IData
    {
        public InsertOrg(DataModels.Organization org)
        {
            CommandText = "InsertOrg";
            CommandType = CommandType.StoredProcedure;
            Parameters = new InsertOrgParameters().Fill(org);
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}