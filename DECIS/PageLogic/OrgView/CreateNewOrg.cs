using DECIS.Utilities;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.OrgView
{
    public class CreateNewOrg
    {
        public static DataModels.Organization Create(Page pg, int id)
        {
            return new DataModels.Organization()
            {
                //Org Info
                OrgID = id,
                OrgName = (FindControl.Find("tbOrgName", pg) as TextBox).Text,
                OrgAddress = (FindControl.Find("tbOrgAddress", pg) as TextBox).Text,
                OrgEmail = (FindControl.Find("tbOrgEmail", pg) as TextBox).Text,
                OrgPhone = (FindControl.Find("tbOrgPhone", pg) as TextBox).Text,
                OrgZipcode = (FindControl.Find("tbOrgZipcode", pg) as TextBox).Text,
                //Primary Contact Info
                OrgContactPrimary = (FindControl.Find("tbPrimaryContact", pg) as TextBox).Text,
                OrgPrimaryPhone = (FindControl.Find("tbPrimaryPhone", pg) as TextBox).Text,
                OrgPrimaryEmail = (FindControl.Find("tbPrimaryEmail", pg) as TextBox).Text,
                OrgContactSecondary = (FindControl.Find("tbSecondaryContact", pg) as TextBox).Text,
                OrgSecondaryPhone = (FindControl.Find("tbSecondaryPhone", pg) as TextBox).Text,
                OrgSecondaryEmail = (FindControl.Find("tbSecondaryEmail", pg) as TextBox).Text,
            };
        }
    }
}