using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    public class User
    {
        public int AccountID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; } // 0 = basic  1 = admin

        public User() { }
        public User(DataRow dr)
        {
            AccountID = int.Parse(dr["AccountID"].ToString());
            Email = dr["Email"].ToString();
            FirstName = dr["FirstName"].ToString();
            LastName = dr["LastName"].ToString();
            Role = int.Parse(dr["Role"].ToString());
        }
    }

}