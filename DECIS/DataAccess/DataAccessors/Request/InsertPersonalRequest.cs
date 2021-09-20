using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class InsertPersonalRequest : DataSupport, IData
    {
        public InsertPersonalRequest(PersonalRequest req)
        {
            CommandText = "InsertPersonalRequest";
            CommandType = CommandType.StoredProcedure;
            Parameters = new PersonalRequestParameters().Fill(req);
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}