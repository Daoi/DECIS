using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using DECIS.DataModels;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class InsertRequest : DataSupport, IData
    {
        public InsertRequest(OrgRequest req)
        {
            CommandText = "InsertRequest";
            CommandType = CommandType.StoredProcedure;
            Parameters = new InsertRequestParameters().Fill(req);
        }

        public int ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery(); 
            return eq.ExecuteNonQuery(this);
        }
    }
}