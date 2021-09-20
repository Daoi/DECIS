using DECIS.DataAccess.DataAccessors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DECIS.PageLogic.RecycleView
{
    public class RemoveAssets
    {
        public static void Remove(List<int> assetIds, int recID)
        {

            var cmdText = assetIds.Aggregate(
                new StringBuilder(),
                (sb, id) => sb.AppendLine($"DELETE FROM recycleditem WHERE RecycleID = " +
                $"'{MySqlHelper.EscapeString(recID.ToString())}' AND AssetID = {MySqlHelper.EscapeString(id.ToString())}; " +
                $"UPDATE asset SET Status = '2' WHERE asset.AssetID = '{MySqlHelper.EscapeString(id.ToString())}';")).ToString(); //Status 2 = BAD
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