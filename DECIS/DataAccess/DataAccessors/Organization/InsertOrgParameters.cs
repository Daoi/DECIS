using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Organization
{
    public class InsertOrgParameters
    {
        private MySqlParameter[] Parameters;


        public InsertOrgParameters()
        {
            Parameters = new MySqlParameter[]
            {
            new MySqlParameter("@OrgName", MySqlDbType.VarChar, 100),
            new MySqlParameter("@OrgAddress", MySqlDbType.VarChar, 150),
            new MySqlParameter("@OrgPhone", MySqlDbType.VarChar, 20),
            new MySqlParameter("@OrgZipcode", MySqlDbType.VarChar, 20),
            new MySqlParameter("@OrgEmail", MySqlDbType.VarChar, 100),
            new MySqlParameter("@OrgContactPrimary", MySqlDbType.VarChar, 100),
            new MySqlParameter("@OrgPrimaryPhone", MySqlDbType.VarChar, 20),
            new MySqlParameter("@OrgPrimaryEmail", MySqlDbType.VarChar, 100),
            new MySqlParameter("@OrgContactSecondary", MySqlDbType.VarChar, 100),
            new MySqlParameter("@OrgSecondaryPhone", MySqlDbType.VarChar, 20),
            new MySqlParameter("@OrgSecondaryEmail", MySqlDbType.VarChar, 100),
            new MySqlParameter("@OrgReferer", MySqlDbType.VarChar, 150),
            new MySqlParameter("@ReceivedEquipment", MySqlDbType.Bit, 1),
            new MySqlParameter("@Purpose", MySqlDbType.VarChar, 500),
            };
        }

        public MySqlParameter[] Fill(DataModels.Organization org)
        {
            Parameters[0].Value = org.OrgName;
            Parameters[1].Value = org.OrgAddress;
            Parameters[2].Value = org.OrgPhone;
            Parameters[3].Value = org.OrgZipcode;
            Parameters[4].Value = org.OrgEmail;
            Parameters[5].Value = org.OrgContactPrimary;
            Parameters[6].Value = org.OrgPrimaryPhone;
            Parameters[7].Value = org.OrgPrimaryEmail;
            Parameters[8].Value = org.OrgContactSecondary;
            Parameters[9].Value = org.OrgSecondaryPhone;
            Parameters[10].Value = org.OrgSecondaryEmail;
            Parameters[11].Value = org.Referer;
            Parameters[12].Value = org.ReceivedEquipment;
            Parameters[13].Value = org.Purpose;


            return Parameters;

        }
    }
}
