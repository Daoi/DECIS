using DECIS.DataAccess.DataAccessors.Organization;
using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.CreateRequest
{
    public class CollectOrgRequestInfo
    {
        public static void Collect(Page pg, bool createOrg = false)
        {
            Organization org;

            Request newReq = CreateRequest.Create(pg);
            try
            {
                if (newReq.OrgID != -1)
                {
                    org = new Organization(new GetOrgByID().ExecuteCommand(newReq.OrgID).Rows[0]);
                    
                }
                else
                {
                    org = CreateOrg.Create(pg, newReq);
                    org.OrgID = (int)new InsertOrg(org).ExecuteCommand().Rows[0].ItemArray[0]; //Create new org and retrieve last inserted ID
                    newReq.OrgID = org.OrgID;
                }
            }
            catch(Exception e)
            {

            }

        }
    }
}