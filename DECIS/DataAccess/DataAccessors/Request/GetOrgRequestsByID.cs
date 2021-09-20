using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class GetOrgRequestsByID : DataSupport, IData
    {
        public GetOrgRequestsByID()
        {
            CommandText = "GetOrgRequestsByID";
            CommandType = CommandType.StoredProcedure;
        }
        /// <summary>
        /// Get requests from a specific org and status. 
        /// </summary>
        /// <param name="orgID"></param>
        /// <param name="status">1 = new, 2 = Pending, 3 = Scheduled, 4 = Finished, 5 = Cancelled</param>
        /// <returns></returns>
        public DataTable ExecuteCommand(int orgID, int status)
        {
            Parameters = new MySqlParameter[2] { new MySqlParameter("OrgID", orgID), new MySqlParameter("Status", status) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}