using DECIS.DataAccess.DataAccessors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DECIS.PageLogic.RequestView
{
    public class AddAssets
    {
        /// <summary>
        /// Only 500 assets can be added/removed at one time because of MySQLs 1000 query limit.
        /// Can increase by counting how many assetIDs and then breaking them up into multiple commands
        /// Very Unlikely to ever do that many at once though.
        /// </summary>
        /// <param name="assetIds"></param>
        /// <param name="reqID"></param>
        public static void Add(List<int> assetIds, int reqID)
        {
            var cmdText = assetIds.Aggregate(
                new StringBuilder(),
                (sb, id) => sb.AppendLine($"INSERT INTO requestitem (RequestID, AssetID) VALUES " +
                $"('{MySqlHelper.EscapeString(reqID.ToString())}',{MySqlHelper.EscapeString(id.ToString())}); " +
                $"UPDATE asset SET Status = '5' WHERE asset.AssetID = '{MySqlHelper.EscapeString(id.ToString())}';")).ToString();
            try
            {
                new CTextWriter(cmdText).ExecuteCommand();
            }
            catch(Exception ex)
            {

            }
        }
    }
}