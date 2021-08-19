using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Documents
{
    public class GetDocumentsByOrgID : DataSupport, IData
    {
        public GetDocumentsByOrgID()
        {
            CommandText = "GetDocumentsByOrgID";
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