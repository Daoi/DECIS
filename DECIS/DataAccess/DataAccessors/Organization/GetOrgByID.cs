using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Organization
{
    public class GetOrgByID : DataSupport, IData
    {
        public GetOrgByID()
        {
            CommandText = "GetOrgByID";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int orgID)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("OrgID", orgID) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}