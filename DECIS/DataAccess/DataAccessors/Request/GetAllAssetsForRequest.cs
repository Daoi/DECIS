using MySql.Data.MySqlClient;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class GetAllAssetsForRequest : DataSupport, IData
    {
        public GetAllAssetsForRequest()
        {
            CommandText = "GetAllAssetsForRequest";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int id)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("RequestID", id) };
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this); 
        }
    }
}