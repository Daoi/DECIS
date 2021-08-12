using DECIS.DataModels;
using DECIS.Utilities;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.OrgView
{
    public class OrgViewDataDisplay
    {
        public static void Display(Page pg, Organization org)
        {
            //Org Info
            (FindControl.Find("lblCardTitle", pg) as Label).Text = $"Org ID: {org.OrgID}";
            (FindControl.Find("tbOrgName", pg) as TextBox).Text = org.OrgName;
            (FindControl.Find("tbOrgAddress", pg) as TextBox).Text = org.OrgAddress;
            (FindControl.Find("tbOrgEmail", pg) as TextBox).Text = org.OrgEmail;
            (FindControl.Find("tbOrgPhone", pg) as TextBox).Text = org.OrgPhone;
            (FindControl.Find("tbOrgZipcode", pg) as TextBox).Text = org.OrgZipcode;
            //Primary Contact Info
            (FindControl.Find("tbPrimaryContact", pg) as TextBox).Text = org.OrgContactPrimary;
            (FindControl.Find("tbPrimaryPhone", pg) as TextBox).Text = org.OrgPrimaryPhone;
            (FindControl.Find("tbPrimaryEmail", pg) as TextBox).Text = org.OrgPrimaryEmail;
            (FindControl.Find("tbSecondaryContact", pg) as TextBox).Text = org.OrgContactSecondary;
            (FindControl.Find("tbSecondaryPhone", pg) as TextBox).Text = org.OrgSecondaryPhone;
            (FindControl.Find("tbSecondaryEmail", pg) as TextBox).Text = org.OrgSecondaryEmail;
        }

    }
}