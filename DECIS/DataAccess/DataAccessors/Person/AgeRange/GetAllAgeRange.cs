using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Person.AgeRange
{
    public class GetAllAgeRange : DataSupport, IData
    {
        public GetAllAgeRange()
        {
            CommandText = "GetAllAgeRange";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}