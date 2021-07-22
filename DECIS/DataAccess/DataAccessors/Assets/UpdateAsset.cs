using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DECIS.DataModels;

namespace DECIS.DataAccess.DataAccessors.Assets
{
    public class UpdateAsset : DataSupport, IData
    {
        public UpdateAsset(Asset asset)
        {
            CommandText = "UpdateAsset";
            CommandType = CommandType.StoredProcedure;
            Parameters = new UpdateAssetParameters().Fill(asset);
        }

        public int ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteNonQuery(this);
        }
    }
}