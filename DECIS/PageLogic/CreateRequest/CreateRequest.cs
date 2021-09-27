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
    public class CreateRequest
    {
        public static OrgRequest Create(Page pg)
        {
            OrgRequest newReq = new OrgRequest()
            {
                OrgID = int.Parse((FindControl.FindNM("ddlOrganization", pg) as DropDownList).SelectedValue),
                Status = 1,
                Name = (FindControl.FindNM("tbName", pg) as TextBox).Text,
                Phone = (FindControl.FindNM("tbPhone", pg) as TextBox).Text,
                Email = (FindControl.FindNM("tbEmail", pg) as TextBox).Text,
                ContactName = (FindControl.FindNM("tbContactName", pg) as TextBox).Text,
                ContactPhone = (FindControl.FindNM("tbContactPhone", pg) as TextBox).Text,
                ContactEmail = (FindControl.FindNM("tbContactEmail", pg) as TextBox).Text,
                Purpose = (FindControl.FindNM("tbPurpose", pg) as TextBox).Text,
                ItemsRequested = (FindControl.FindNM("tbSpecs", pg) as TextBox).Text,
                Timeline = (FindControl.FindNM("tbTimeline", pg) as TextBox).Text,
                Type = 0,
                DateSubmitted = DateTime.Today.ToShortDateString()
            };

            return newReq;
        }

        public static PersonalRequest CreatePersonal(Page pg)
        {
            PersonalRequest newReq = new PersonalRequest()
            {
                OrgID = int.Parse((FindControl.FindNM("ddlOrganization", pg) as DropDownList).SelectedValue),
                Status = 1,
                Name = (FindControl.FindNM("tbName", pg) as TextBox).Text,
                Phone = (FindControl.FindNM("tbPhone", pg) as TextBox).Text,
                Email = (FindControl.FindNM("tbEmail", pg) as TextBox).Text,
                Type = 1,
                Internet = (FindControl.FindNM("ddlInternet", pg) as DropDownList).SelectedValue == "1" ? true : false,
                DateSubmitted = DateTime.Today.ToShortDateString()
            };

            return newReq;
        }
    }
}