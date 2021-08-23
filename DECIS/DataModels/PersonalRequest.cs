using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    public class PersonalRequest : Request
    {
        public bool Internet { get; set; }
        public int PersonID { get; set; }

        public PersonalRequest() { }

        public PersonalRequest(DataRow dr) : base(dr)
        {
            PersonID = int.Parse(dr["Person"].ToString());
            Internet = dr["Internet"] == DBNull.Value ? false : (bool)dr["Internet"];

        }
    }
}