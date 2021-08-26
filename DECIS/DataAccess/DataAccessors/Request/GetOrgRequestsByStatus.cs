using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class GetOrgRequestsByStatus : DataSupport, IData
    {
        public GetOrgRequestsByStatus()
        {
            CommandText = "GetOrgRequestsByStatus";
            CommandType = CommandType.StoredProcedure;
        }
        /// <summary>
        /// Used to get all requests from all orgs by status
        /// </summary>
        /// <param name="orgID"></param>
        /// <param name="status">1 = new, 2 = Pending, 3 = Scheduled, 4 = Finished, 5 = Cancelled</param>
        /// <returns></returns>
        public DataTable ExecuteCommand(int status)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("Status", status) };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}