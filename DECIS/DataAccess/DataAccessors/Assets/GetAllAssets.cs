using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DECIS.DataAccess.DataAccessors
{
    public class GetAllAssets : DataSupport, IData
    {
        public GetAllAssets()
        {
            CommandText = "GetAllAssets";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}