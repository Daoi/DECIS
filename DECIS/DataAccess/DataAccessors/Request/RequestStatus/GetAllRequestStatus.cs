using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Request.RequestStatus
{
    public class GetAllRequestStatus : DataSupport, IData
    {
        public GetAllRequestStatus()
        {
            CommandText = "GetAllRequestStatus";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}