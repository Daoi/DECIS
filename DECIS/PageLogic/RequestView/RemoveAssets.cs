using DECIS.DataAccess.DataAccessors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DECIS.PageLogic.RequestView
{
    public class RemoveAssets
    {
        public static void Remove(List<int> assetIds, int reqID)
        {

            var cmdText = assetIds.Aggregate(
                new StringBuilder(),
                (sb, id) => sb.AppendLine($"DELETE FROM requestitem WHERE RequestID = " +
                $"'{MySqlHelper.EscapeString(reqID.ToString())}' AND AssetID = {MySqlHelper.EscapeString(id.ToString())}; " +
                $"UPDATE asset SET Status = '1' WHERE asset.AssetID = '{MySqlHelper.EscapeString(id.ToString())}';")).ToString();
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