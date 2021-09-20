using DECIS.DataAccess.DataAccessors.Recycle;
using DECIS.DataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.PageLogic.RecycleList
{
    public class CreateNewRecycle
    {
        public static int Create()
        {
            try
            {
                return RetrieveLastInsertedID.RetrieveID(new InsertNewRecycle().ExecuteCommand());
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}