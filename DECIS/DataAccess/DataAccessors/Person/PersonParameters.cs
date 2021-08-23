using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.DataAccessors.Person
{
    public class PersonParameters
    {
        private MySqlParameter[] Parameters;


        public PersonParameters()
        {
            Parameters = new MySqlParameter[]
            {
                new MySqlParameter("@PersonID", MySqlDbType.Int32),
                new MySqlParameter("@FirstName", MySqlDbType.VarChar, 45),
                new MySqlParameter("@LastName", MySqlDbType.VarChar, 45),
                new MySqlParameter("@Gender", MySqlDbType.Int32),
                new MySqlParameter("@Race", MySqlDbType.Int32),
                new MySqlParameter("@Ethnicity", MySqlDbType.Int32),
                new MySqlParameter("@Phone", MySqlDbType.VarChar, 20),
                new MySqlParameter("@Email", MySqlDbType.VarChar, 100),
                new MySqlParameter("@Zipcode", MySqlDbType.VarChar, 20),
                new MySqlParameter("@Adult", MySqlDbType.Int32),
                new MySqlParameter("@HSStudent", MySqlDbType.Int32),
                new MySqlParameter("@K8Student", MySqlDbType.Int32),
                new MySqlParameter("@Preschool", MySqlDbType.Int32),


            };
        }

        public MySqlParameter[] Fill(DataModels.Person p)
        {
            Parameters[0].Value = p.PersonID;
            Parameters[1].Value = p.FirstName;
            Parameters[2].Value = p.LastName;
            Parameters[3].Value = p.Gender;
            Parameters[4].Value = p.Race;
            Parameters[5].Value = p.Ethnicity;
            Parameters[6].Value = p.Phone;
            Parameters[7].Value = p.Email;
            Parameters[8].Value = p.ZipCode;
            Parameters[9].Value = p.Adult;
            Parameters[10].Value = p.HSStudent;
            Parameters[11].Value = p.K8Student;
            Parameters[12].Value = p.Preschool;

            return Parameters;

        }
    }
}