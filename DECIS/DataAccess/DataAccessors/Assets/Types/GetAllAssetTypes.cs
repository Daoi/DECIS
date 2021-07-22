using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Assets.Types
{
    public class GetAllAssetTypes : DataSupport, IData
    {
        public GetAllAssetTypes()
        {
            CommandText = "GetAllAssetTypes";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}