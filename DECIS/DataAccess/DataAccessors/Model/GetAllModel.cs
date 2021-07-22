using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Model
{
    public class GetAllModel : DataSupport, IData
    {
        public GetAllModel()
        {
            CommandText = "GetAllModel";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}