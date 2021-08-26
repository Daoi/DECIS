using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class GetRequestInfoByID : DataSupport, IData
    {
        public GetRequestInfoByID()
        {
            CommandText = "GetRequestInfoByID";
            CommandType = CommandType.StoredProcedure;
        }
        
        /// <summary>
        /// Get a specific request by its ID
        /// </summary>
        /// <param name="reqID">ID to look for</param>
        /// <param name="type">0 = Org request 1 = Personal Request</param>
        /// <returns></returns>
        public DataTable ExecuteCommand(int reqID, int type)
        {
            Parameters = new MySqlParameter[2] { new MySqlParameter("RequestID", reqID), new MySqlParameter("RequestType", type) };
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}