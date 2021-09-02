using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Person
{
    public class GetAssociatedPeople : DataSupport, IData
    {
        public GetAssociatedPeople()
        {
            CommandText = "GetAssociatedPeople";
            CommandType = CommandType.StoredProcedure;
        }
        /// <summary>
        /// Get all associated requests for an Org of a type
        /// </summary>
        /// <param name="orgID">The org the requests should belong to</param>
        /// <param name="type">0 = org request, 1 = personal request</param>
        /// <returns></returns>
        public DataTable ExecuteCommand(int orgID)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("OrgID", orgID) };
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}