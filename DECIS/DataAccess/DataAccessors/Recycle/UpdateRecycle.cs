using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Recycle
{
    public class UpdateRecycle : DataSupport, IData
    {
        public UpdateRecycle(DataModels.Recycle r)
        {
            CommandText = "UpdateRecycle";
            CommandType = CommandType.StoredProcedure;
            Parameters = new UpdateRecycleParameters().Fill(r);
        }

        public int ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteNonQuery(this);
        }
    }
}