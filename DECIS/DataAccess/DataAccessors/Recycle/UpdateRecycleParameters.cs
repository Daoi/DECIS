using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Recycle
{
    public class UpdateRecycleParameters
    {
        private MySqlParameter[] Parameters;


        public UpdateRecycleParameters()
        {
            Parameters = new MySqlParameter[]
            {
            new MySqlParameter("@RecycleID", MySqlDbType.Int32),
            new MySqlParameter("@RecycleDate", MySqlDbType.VarChar, 20),
            new MySqlParameter("@RecycleStatus", MySqlDbType.Int32),
            new MySqlParameter("@RecycleReceiver", MySqlDbType.Int32),

            };
        }

        public MySqlParameter[] Fill(DataModels.Recycle r)
        {
            Parameters[0].Value = r.RecycleID;
            Parameters[1].Value = r.Date;
            Parameters[2].Value = r.RecycleStatus;
            Parameters[3].Value = r.RecycleReceiver;

            return Parameters;
        }
    }
}