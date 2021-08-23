using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Person
{
    public class InsertPerson : DataSupport, IData
    {
        public InsertPerson(DataModels.Person p)
        {
            CommandText = "InsertPerson";
            CommandType = CommandType.StoredProcedure;
            Parameters = new PersonParameters().Fill(p);
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteAdapter(this);
        }
    }
}