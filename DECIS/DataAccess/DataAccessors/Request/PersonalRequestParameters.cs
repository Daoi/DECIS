using DECIS.DataModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class PersonalRequestParameters
    {
        private MySqlParameter[] Parameters;


        public PersonalRequestParameters()
        {
            Parameters = new MySqlParameter[]
            {
                new MySqlParameter("@RequestID", MySqlDbType.Int32),
                new MySqlParameter("@Status", MySqlDbType.Int32),
                new MySqlParameter("@Name", MySqlDbType.VarChar, 100),
                new MySqlParameter("@Email", MySqlDbType.VarChar, 100),
                new MySqlParameter("@Phone", MySqlDbType.VarChar, 20),
                new MySqlParameter("@Notes", MySqlDbType.VarChar, 400),
                new MySqlParameter("@DateSubmitted", MySqlDbType.VarChar, 10),
                new MySqlParameter("@DateFinished", MySqlDbType.VarChar, 10),
                new MySqlParameter("@Internet", MySqlDbType.Bit, 1),
                new MySqlParameter("@PersonID", MySqlDbType.Int32),
                new MySqlParameter("@Keyboard", MySqlDbType.Int32),
                new MySqlParameter("@Mice", MySqlDbType.Int32),
                new MySqlParameter("@Wifi", MySqlDbType.Int32),
                new MySqlParameter("@Webcam", MySqlDbType.Int32),
                new MySqlParameter("@OrgID", MySqlDbType.Int32),
                new MySqlParameter("@DateScheduled", MySqlDbType.VarChar, 10),

            };
        }

        public MySqlParameter[] Fill(PersonalRequest req)
        {
            Parameters[0].Value = req.RequestID;
            Parameters[1].Value = req.Status;
            Parameters[2].Value = req.Name;
            Parameters[3].Value = req.Email;
            Parameters[4].Value = req.Phone;
            Parameters[5].Value = req.Notes;
            Parameters[6].Value = req.DateSubmitted;
            Parameters[7].Value = req.DateFinished;
            Parameters[8].Value = req.Internet;
            Parameters[9].Value = req.PersonID;
            Parameters[10].Value = req.Keyboard;
            Parameters[11].Value = req.Mice;
            Parameters[12].Value = req.Wifi;
            Parameters[13].Value = req.Webcam;
            Parameters[14].Value = req.OrgID;
            Parameters[15].Value = req.DateScheduled;

            return Parameters;
        }
    }
}