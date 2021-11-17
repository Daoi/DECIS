using DECIS.DataAccess.DataAccessors.Person;
using DECIS.DataAccess.DataAccessors.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.OrgView
{
    [Serializable]
    public class BindGridviews
    {
        private DataTable gvIncompleteRequests;
        private DataTable gvCompletedRequestDT;
        private DataTable gvPeopleDT;
        private const int ORG = 0;
        private const int PERSONAL = 1;


        public BindGridviews(int orgID)
        {
            gvIncompleteRequests = new GetAllIncompleteRequestsForOrg().ExecuteCommand(orgID);
            gvCompletedRequestDT = new GetAllCompletedRequestsForOrg().ExecuteCommand(orgID);
            gvPeopleDT = new GetAssociatedPeople().ExecuteCommand(orgID);
        }

        public bool Bind(List<GridView> gvs) 
        {
            try
            {
                foreach (GridView gv in gvs)
                {
                    if (gv.ID == "gvRequests")
                    {
                        gv.DataSource = gvIncompleteRequests;
                        gv.DataBind();
                    }
                    else if (gv.ID == "gvPeople")
                    {
                        gv.DataSource = gvPeopleDT;
                        gv.DataBind();
                    }
                    else if (gv.ID == "gvCompletedRequests")
                    {
                        gv.DataSource = gvCompletedRequestDT;
                        gv.DataBind();
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
    }
}