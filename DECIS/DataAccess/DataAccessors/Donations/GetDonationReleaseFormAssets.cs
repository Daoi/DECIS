using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Donations
{
    public class GetDonationReleaseFormAssets : DataSupport, IData
    {
        public GetDonationReleaseFormAssets()
        {
            CommandText = "GetDonationReleaseFormAssets";
            CommandType = CommandType.StoredProcedure;
        }

        /// <summary>
        /// Get a specific request by its ID
        /// </summary>
        /// <param name="reqID">ID to look for</param>
        /// <param name="type">0 = Org request 1 = Personal Request</param>
        /// <returns></returns>
        public DataTable ExecuteCommand(int reqID)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("RequestID", reqID) };
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}