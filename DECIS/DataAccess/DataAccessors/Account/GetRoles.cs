using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Account
{
    public class GetRoles : DataSupport, IData
    {
        public GetRoles()
        {
            CommandText = "GetRoles";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery(); 
            return eq.ExecuteAdapter(this); 
        }
    }
}