using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Organization
{
    public class GetOrgNameByID : DataSupport, IData
    {
        public GetOrgNameByID()
        {
            CommandText = "GetOrgNameByID";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int orgID)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("OrgID", orgID) };
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}