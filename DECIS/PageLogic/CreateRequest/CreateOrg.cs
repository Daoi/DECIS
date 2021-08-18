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
    public class CreateOrg
    {
        public static Organization Create(Page pg, OrgRequest req)
        {
            Organization org = new Organization()
            {
                OrgName = (FindControl.FindNM("tbOrgName", pg) as TextBox).Text,
                Purpose = (FindControl.FindNM("tbOrgPurpose", pg) as TextBox).Text,
                Referer = (FindControl.FindNM("tbReferer", pg) as TextBox).Text,
                OrgZipcode = (FindControl.FindNM("tbZipcode", pg) as TextBox).Text,
                OrgContactPrimary = (FindControl.FindNM("tbName", pg) as TextBox).Text,
                OrgPrimaryPhone = (FindControl.FindNM("tbPhone", pg) as TextBox).Text,
                OrgPrimaryEmail = (FindControl.FindNM("tbEmail", pg) as TextBox).Text,
                ReceivedEquipment = (FindControl.FindNM("ddlReceivedEquipment", pg) as DropDownList).SelectedValue == "1" //If its 1 they've recieved equipment
            };

            if (req.ContactName != org.OrgContactPrimary)
            {
                org.OrgContactSecondary = req.ContactName;
                org.OrgSecondaryEmail = req.ContactPhone;
                org.OrgSecondaryPhone = req.ContactEmail;
            }

            return org;
        }
    }
}