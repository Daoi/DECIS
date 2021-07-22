using DECIS.DataModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Assets
{
    public class UpdateAssetParameters
    {
        private MySqlParameter[] Parameters;


        public UpdateAssetParameters()
        {
            Parameters = new MySqlParameter[]
            {
                new MySqlParameter("@AssetID", MySqlDbType.Int32),
                new MySqlParameter("@AssetDescription", MySqlDbType.VarChar, 300),
                new MySqlParameter("@ModelID", MySqlDbType.Int32),
                new MySqlParameter("@SerialNumber", MySqlDbType.VarChar, 50),
                new MySqlParameter("@StatusID", MySqlDbType.Int32),
                new MySqlParameter("LocationID", MySqlDbType.Int32)

            };
        }

        public MySqlParameter[] Fill(Asset asset)
        {
            Parameters[0].Value = asset.AssetID;
            Parameters[1].Value = asset.Description;
            Parameters[2].Value = asset.ModelID;
            Parameters[3].Value = asset.SerialNumber;
            Parameters[4].Value = asset.StatusID;
            Parameters[5].Value = asset.LocationID;
            return Parameters;

        }
    }
}