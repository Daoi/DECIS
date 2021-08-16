using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.CreateRequest
{
    public class CollectOrgRequestInfo
    {
        public static void Collect(Page pg, int orgID = -1, bool createOrg = false)
        {
            Request newReq = new Request()
            {
                OrgID = int.Parse((FindControl.FindNM("ddlOrg", pg) as DropDownList).SelectedValue),
                Status = 0,
                Name = (FindControl.FindNM("tbName", pg) as TextBox).Text,
                Phone = (FindControl.FindNM("tbPhone", pg) as TextBox).Text,
                Email = (FindControl.FindNM("tbEmail", pg) as TextBox).Text,
                ContactName = (FindControl.FindNM("tbContactName", pg) as TextBox).Text,
                ContactPhone = (FindControl.FindNM("tbContactPhone", pg) as TextBox).Text,
                ContactEmail = (FindControl.FindNM("tbContactEmail", pg) as TextBox).Text,
                Purpose = (FindControl.FindNM("tbPurpose", pg) as TextBox).Text,
                ItemsRequested = (FindControl.FindNM("tbSpecs", pg) as TextBox).Text,
                Timeline = (FindControl.FindNM("tbTimeline", pg) as TextBox).Text,
                DateSubmitted = DateTime.Today.ToShortDateString()
            };
            //Request Contact Info
            string ocs = (FindControl.FindNM("tbContactName", pg) as TextBox).Text;
            string osp = (FindControl.FindNM("tbOrgSecondaryPhone", pg) as TextBox).Text;
            string ose = (FindControl.FindNM("tbContactEmail", pg) as TextBox).Text;

            Organization org = new Organization()
            {
                OrgName = (FindControl.FindNM("tbOrgName", pg) as TextBox).Text,
                Purpose = (FindControl.FindNM("tbOrgPurpose", pg) as TextBox).Text,
                Referer = (FindControl.FindNM("tbReferer", pg) as TextBox).Text,
                OrgZipcode = (FindControl.FindNM("tbZipcode", pg) as TextBox).Text,
                OrgContactPrimary = (FindControl.FindNM("tbName", pg) as TextBox).Text,
                OrgPrimaryPhone = (FindControl.FindNM("tbPhone", pg) as TextBox).Text,
                OrgPrimaryEmail = (FindControl.FindNM("tbEmail", pg) as TextBox).Text,
                RecievedEquipment = (FindControl.Find("ddlRecievedEquipment", pg) as DropDownList).SelectedValue == "1" //If its 1 they've recieved equipment
            };
            //If Requestor and Contact aren't the same person store both
            if (ocs != org.OrgContactPrimary)
            {
                org.OrgContactSecondary = ocs;
                org.OrgSecondaryEmail = ose;
                org.OrgSecondaryPhone = osp;
            }

            if (createOrg)
            {
                //Create Org
                //Set Org ID after creating
            }
            else
            {
                org.OrgID = orgID;
                //Update Org
            }

        }
    }
}