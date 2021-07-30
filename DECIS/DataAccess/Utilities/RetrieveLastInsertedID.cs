using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataAccess.Utilities
{
    public class RetrieveLastInsertedID
    {
        public static int RetrieveID(DataTable dt)
        {
            int id;
            bool result = int.TryParse(dt.Rows[0].ItemArray[0].ToString(), out id);
            if (result)
                return id;
            else
                return -1;
        }
    }
}