using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Person.Ethnicity
{
    public class GetAllEthnicity : DataSupport, IData
    {
        public GetAllEthnicity()
        {
            CommandText = "GetAllEthnicity";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}