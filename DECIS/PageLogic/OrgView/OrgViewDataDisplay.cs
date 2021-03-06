using DECIS.ControlLogic.Gridview;
using DECIS.DataAccess.DataAccessors.Request;
using DECIS.DataModels;
using DECIS.Utilities;
using System.Data;
using System.Linq;
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
            (FindControl.Find("ddlReceivedEquipment", pg) as DropDownList).SelectedValue = (org.ReceivedEquipment ? 1 : 0).ToString();
            (FindControl.Find("tbOrgPurpose", pg) as TextBox).Text = org.Purpose;
            (FindControl.Find("tbOrgReferer", pg) as TextBox).Text = org.Referer;
            //Primary Contact Info
            (FindControl.Find("tbPrimaryContact", pg) as TextBox).Text = org.OrgContactPrimary;
            (FindControl.Find("tbPrimaryPhone", pg) as TextBox).Text = org.OrgPrimaryPhone;
            (FindControl.Find("tbPrimaryEmail", pg) as TextBox).Text = org.OrgPrimaryEmail;
            (FindControl.Find("tbSecondaryContact", pg) as TextBox).Text = org.OrgContactSecondary;
            (FindControl.Find("tbSecondaryPhone", pg) as TextBox).Text = org.OrgSecondaryPhone;
            (FindControl.Find("tbSecondaryEmail", pg) as TextBox).Text = org.OrgSecondaryEmail;

            //GridViews
            DataTable requestDT = new GetAllOrgRequestsByID().ExecuteCommand(org.OrgID);
            GridView gvRequests = (FindControl.Find("gvRequests", pg) as GridView);

            //Uncompleted Requests
            DataTableFilter.Filter(requestDT, gvRequests, r => int.Parse(r["Status"].ToString()) < 4);
            //Cancelled/Finished 
            DataTableFilter.Filter(requestDT, gvRequests, r => int.Parse(r["Status"].ToString()) > 3);
        }

    }
}