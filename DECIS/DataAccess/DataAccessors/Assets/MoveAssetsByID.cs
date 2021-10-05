using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Assets
{
    public class MoveAssetsByID
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assetIds"></param>
        /// <param name="LocationID">47 = Donated default location, 52 = Recycled Default location</param>
        public static void Move(List<int> assetIds, int LocationID)
        {
            var cmdText = assetIds.Aggregate(
                new StringBuilder(),
                (sb, id) => sb.AppendLine($"UPDATE asset SET Location = '{LocationID}' WHERE asset.AssetID = '{MySqlHelper.EscapeString(id.ToString())}';")).ToString(); //Status 5 = Donated Location 43 = Donated default location
            try
            {
                new CTextWriter(cmdText).ExecuteCommand();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}