using DECIS.DataAccess.DataAccessors.Donations;
using DECIS.DataAccess.DataAccessors.Request;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.DonationForm
{
    public class Display
    {
        static DataRow info;
        static Page page;
        public static void DisplayData(Page pg, int requestID, int type)
        {
            info = new GetRequestInfoByID().ExecuteCommand(requestID, type).Rows[0];
            page = pg;

            if (type == 0)
                DisplayOrg();
            else
                DisplayPersonal();
        }

        private static void DisplayPersonal()
        {
            (FindControl.FindNM("lblSubmissionDateText", page) as Label).Text = info.Field<string>("DateSubmitted");
            (FindControl.FindNM("lblRequestIDText", page) as Label).Text = info.Field<int>("RequestID").ToString();
            (FindControl.FindNM("lblOrganizationText", page) as Label).Text = info.Field<string>("OrgName");
            (FindControl.FindNM("lblEmailText", page) as Label).Text = info.Field<string>("Email");
            (FindControl.FindNM("lblContactPersonText", page) as Label).Text = info.Field<string>("Name");
            (FindControl.FindNM("lblAddressText", page) as Label).Text = "N/A";
            (FindControl.FindNM("lblZipCodeText", page) as Label).Text = info.Field<string>("Zipcode");
            (FindControl.FindNM("lblPhoneNumberText", page) as Label).Text = info.Field<string>("Phone");
            (FindControl.FindNM("lblWaiverName", page) as Label).Text = info.Field<string>("Name");
            (FindControl.FindNM("lblAcquName", page) as Label).Text = info.Field<string>("Name");
            (FindControl.FindNM("divClasses", page) as Panel).Visible = true;

        }

        private static void DisplayOrg()
        {
            (FindControl.FindNM("lblSubmissionDateText", page) as Label).Text = info.Field<string>("DateSubmitted");
            (FindControl.FindNM("lblRequestIDText", page) as Label).Text = info.Field<int>("RequestID").ToString();
            (FindControl.FindNM("lblOrganizationText", page) as Label).Text = info.Field<string>("OrgName");
            (FindControl.FindNM("lblEmailText", page) as Label).Text = info.Field<string>("ContactEmail");
            (FindControl.FindNM("lblContactPersonText", page) as Label).Text = info.Field<string>("ContactName");
            (FindControl.FindNM("lblAddressText", page) as Label).Text = info.Field<string>("OrgAddress");
            (FindControl.FindNM("lblZipCodeText", page) as Label).Text = info.Field<string>("OrgZipcode");
            (FindControl.FindNM("lblPhoneNumberText", page) as Label).Text = info.Field<string>("Phone");
            (FindControl.FindNM("lblWaiverName", page) as Label).Text = info.Field<string>("ContactName");
            (FindControl.FindNM("lblAcquName", page) as Label).Text = info.Field<string>("ContactName");
        }
    }
}