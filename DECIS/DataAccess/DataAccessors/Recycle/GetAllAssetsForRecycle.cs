using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Recycle
{
    public class GetAllAssetsForRecycle : DataSupport, IData
    {
        public GetAllAssetsForRecycle()
        {
            CommandText = "GetAllAssetsForRecycle";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(int id)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("RecycleID", id) };
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}