using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class GetAllOrgRequestsByID : DataSupport, IData
    {
        public GetAllOrgRequestsByID()
        {
            CommandText = "GetAllOrgRequestsByID";
            CommandType = CommandType.StoredProcedure;
        }
        /// <summary>
        /// Get tall requests belonging to a specified org.
        /// </summary>
        /// <param name="orgID"></param>
        /// <returns></returns>
        public DataTable ExecuteCommand(int orgID)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("OrgID", orgID) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}