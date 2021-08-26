using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Assets
{
    /// <summary>
    /// Returns all assets that aren't donated(5) or Recycled(6)
    /// </summary>
    public class GetAllActiveAssets : DataSupport, IData
    {
        public GetAllActiveAssets()
        {
            CommandText = "GetAllActiveAssets";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}