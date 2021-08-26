using DECIS.DataAccess.DataAccessors;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DECIS.PageLogic.CreateRequest
{
    public class CreatePersonalReasons
    {
        public static void Insert(List<int> reasonIds, int reqID)
        {
            var cmdText = reasonIds.Aggregate(
                new StringBuilder(),
                (sb, id) => sb.AppendLine($"INSERT INTO requestreason (PersonalRequestID, Reason) VALUES " +
                $"('{MySqlHelper.EscapeString(reqID.ToString())}',{MySqlHelper.EscapeString(id.ToString())});")).ToString();
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