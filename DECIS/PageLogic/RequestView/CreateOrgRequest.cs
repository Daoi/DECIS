using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.RequestView
{
    public class CreateOrgRequest
    {
        public static OrgRequest Create(Page pg, int requestID)
        {
            OrgRequest newRequest = new OrgRequest()
            {
                RequestID = requestID,
                OrgName = (FindControl.Find("lblOrgNameText", pg) as Label).Text,
                Status = int.Parse((FindControl.Find("ddlRequestStatus", pg) as DropDownList).SelectedValue),
                Name = (FindControl.Find("tbRequesterName", pg) as TextBox).Text,
                Phone = (FindControl.Find("tbRequesterPhone", pg) as TextBox).Text,
                Email = (FindControl.Find("tbRequesterEmail", pg) as TextBox).Text,
                Notes = (FindControl.Find("tbRequestNotes", pg) as TextBox).Text,
                Keyboard = int.Parse((FindControl.Find("tbKeyboard", pg) as TextBox).Text),
                Mice = int.Parse((FindControl.Find("tbMice", pg) as TextBox).Text),
                Wifi = int.Parse((FindControl.Find("tbWifi", pg) as TextBox).Text),
                Headset = int.Parse((FindControl.Find("tbHeadset", pg) as TextBox).Text),
                Webcam = int.Parse((FindControl.Find("tbWebcam", pg) as TextBox).Text),
                DateSubmitted = (FindControl.Find("tbDateSubmitted", pg) as TextBox).Text,
                DateFinished = (FindControl.Find("tbDateFinished", pg) as TextBox).Text,
                DateScheduled = (FindControl.Find("tbDateScheduled", pg) as TextBox).Text,
                Type = 0,
                ContactName = (FindControl.Find("tbOne", pg) as TextBox).Text,
                ContactPhone = (FindControl.Find("tbTwo", pg) as TextBox).Text,
                ContactEmail = (FindControl.Find("tbThree", pg) as TextBox).Text,
                Purpose = (FindControl.Find("tbRequestPurpose", pg) as TextBox).Text,
                Timeline = (FindControl.Find("tbFive", pg) as TextBox).Text,
                ItemsRequested = (FindControl.Find("tbSix", pg) as TextBox).Text
            };

            return newRequest;
        }
    }
}