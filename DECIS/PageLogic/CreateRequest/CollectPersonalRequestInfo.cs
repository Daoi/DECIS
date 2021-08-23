using DECIS.DataAccess.DataAccessors.Person;
using DECIS.DataAccess.Utilities;
using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.CreateRequest
{
    public class CollectPersonalRequestInfo
    {
        public static void Collect(Page pg, int orgID)
        {
            Person p = CreatePerson.Create(pg);
            PersonalRequest req = CreateRequest.CreatePersonal(pg);
            try
            {
                int pid = RetrieveLastInsertedID.RetrieveID(new InsertPerson(p).ExecuteCommand());
                req.PersonID = pid;
                //Insert Request and Link Request/Org/Person
            }
            catch(Exception e)
            {

            }

        }
    }
}