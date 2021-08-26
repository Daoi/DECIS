using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class UpdatePersonalRequest : DataSupport, IData
    {
        public UpdatePersonalRequest(PersonalRequest req)
        {
            CommandText = "UpdatePersonalRequest";
            CommandType = CommandType.StoredProcedure;
            Parameters = new PersonalRequestParameters().Fill(req);
        }

        public int ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteNonQuery(this);
        }
    }
}