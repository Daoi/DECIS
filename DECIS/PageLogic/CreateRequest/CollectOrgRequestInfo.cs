using DECIS.DataAccess.DataAccessors.Organization;
using DECIS.DataAccess.Utilities;
using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.CreateRequest
{
    public class CollectOrgRequestInfo
    {
        public static (Organization org, OrgRequest req) Collect(Page pg, bool createOrg = false)
        {
            Organization org;

            OrgRequest newReq = CreateRequest.Create(pg);
            try
            {
                if (newReq.OrgID != -1)
                {
                    org = new Organization(new GetOrgByID().ExecuteCommand(newReq.OrgID).Rows[0]);
                }
                else
                {
                    org = CreateOrg.Create(pg, newReq);
                    org.OrgID = RetrieveLastInsertedID.RetrieveID(new InsertOrg(org).ExecuteCommand()); //Create new org and retrieve last inserted ID
                    newReq.OrgID = org.OrgID;
                }

                return (org, newReq);
            }
            catch(Exception e)
            {
                return (null, null);
            }

        }
    }
}