using DECIS.DataAccess.DataAccessors.Organization;
using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.CreateRequest
{
    public class DisplayInfo
    {
        /// <summary>
        /// Display non private org info
        /// </summary>
        /// <param name="orgID"></param>
        /// <param name="pg"></param>
        /// <param name="personal">If its a personal request we dont need to show org info beyond name</param>
        public static Organization DisplayOrgInfo(string orgID, Page pg, bool personal = false)
        {

            int id;
            if (!int.TryParse(orgID, out id))
                throw new InvalidCastException("The ID provided is invalid");

            if (id == -1)
                return null;

            Organization selectedOrg = new Organization(new GetOrgByID().ExecuteCommand(id).Rows[0]);
            Panel pnlShared = (FindControl.FindNM("pnlShared", pg) as Panel);
            TextBox tbOrg = (FindControl.FindInPanel("tbOrgName", pnlShared) as TextBox);

            tbOrg.Text = selectedOrg.OrgName;

            //Personal Request
            if (personal)
            {
                tbOrg.Enabled = false;
                tbOrg.Text = "Must be affiliated with a valid org to recieve equipment";
                return selectedOrg;
            }
            else
                tbOrg.Enabled = true;

            //Org Requests
            Panel pnlOrg = (FindControl.FindNM("pnlOrg", pg) as Panel);
            bool re = selectedOrg.RecievedEquipment;
            string referer = (FindControl.FindInPanel("tbReferer", pnlOrg) as TextBox).Text;

            //Always visible
            (FindControl.FindInPanel("tbZipcode", pnlShared) as TextBox).Text = selectedOrg.OrgZipcode;
            (FindControl.FindInPanel("tbOrgPurpose", pnlOrg) as TextBox).Text = selectedOrg.Purpose;

            //Don't need to ask who referred them again if they already told us
            if (!string.IsNullOrEmpty(selectedOrg.Referer))
                (FindControl.FindInPanel("tbReferer", pnlOrg) as TextBox).Visible = false;
            //If we already know they recieved equipment
            if (!re)
            {
                (FindControl.FindInPanel("lblRecievedEquipment", pnlOrg) as Label).Visible = true;
                (FindControl.FindInPanel("ddlRecievedEquipment", pnlOrg) as DropDownList).Visible = true;
            }

            return selectedOrg;
        }
    }
}