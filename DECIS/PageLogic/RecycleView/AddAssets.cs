using DECIS.DataAccess.DataAccessors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DECIS.PageLogic.RecycleView
{
    public class AddAssets
    {/// <summary>
    /// Limit of 500 assets per recycle. Adds items to a specific recycle ID.
    /// </summary>
    /// <param name="assetIds"></param>
    /// <param name="recycleID"></param>
        public static void Add(List<int> assetIds, int recycleID)
        {
            var cmdText = assetIds.Aggregate(
                new StringBuilder(),
                (sb, id) => sb.AppendLine($"INSERT INTO recycleditem (RecycleID, AssetID) VALUES " +
                $"('{MySqlHelper.EscapeString(recycleID.ToString())}',{MySqlHelper.EscapeString(id.ToString())}); " +
                $"UPDATE asset SET Status = '6' WHERE asset.AssetID = '{MySqlHelper.EscapeString(id.ToString())}';")).ToString(); //STATUS 6 = Recycled
            try
            {
                new CTextWriter(cmdText).ExecuteCommand();
            }
            catch (Exception ex)
            {

            }
        }
    }
}