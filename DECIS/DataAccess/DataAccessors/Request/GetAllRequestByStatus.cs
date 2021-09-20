using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class GetAllRequestByStatus : DataSupport, IData
    {
        public GetAllRequestByStatus()
        {
            CommandText = "GetAllRequestByStatus";
            CommandType = CommandType.StoredProcedure;
        }


        public DataTable ExecuteCommand(int status)
        {
            Parameters = new MySqlParameter[1] { new MySqlParameter("Status", status) };
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}