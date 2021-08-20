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
        public static void Add(List<int> assetIds, int reqID)
        {
            StringBuilder sCommand = new StringBuilder("INSERT INTO requestItem (RequestID, AssetID) VALUES ");
            List<string> rows = new List<string>(); //The rows to insert
            foreach (int i in assetIds)
            {
                rows.Add(string.Format($"('{MySqlHelper.EscapeString(reqID.ToString())}'," +
                    $"'{MySqlHelper.EscapeString(i.ToString())}')"));
            }
            sCommand.Append(string.Join(",", rows));
            sCommand.Append(";");
            try
            {
                new CTextWriter(sCommand.ToString()).ExecuteCommand();
            }
            catch(Exception ex)
            {

            }
        }
    }
}