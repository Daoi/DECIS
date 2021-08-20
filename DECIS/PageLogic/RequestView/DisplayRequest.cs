using DECIS.CotrolLogic.DDL;
using DECIS.DataAccess.DataAccessors;
using DECIS.DataAccess.DataAccessors.Organization;
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
    public class DisplayRequest
    {
        Page pg;
        public static void Display(Page pg, Request req)
        {
            DropDownList ddlRequestStatus = (FindControl.Find("ddlRequestStatus", pg) as DropDownList);
            DDLDataBind.Bind(new List<DropDownList>() { ddlRequestStatus });
            ddlRequestStatus.SelectedValue = req.Status.ToString();

            (FindControl.Find("lblOrgNameText", pg) as Label).Text = req.OrgName;
            (FindControl.Find("tbRequesterName", pg) as TextBox).Text = req.Name;
            (FindControl.Find("tbRequesterPhone", pg) as TextBox).Text = req.Phone;
            (FindControl.Find("tbRequesterEmail", pg) as TextBox).Text = req.Email;
            (FindControl.Find("tbRequestNotes", pg) as TextBox).Text = req.Notes;
            (FindControl.Find("tbKeyboard", pg) as TextBox).Text = req.Keyboard.ToString();
            (FindControl.Find("tbMice", pg) as TextBox).Text = req.Mice.ToString();
            (FindControl.Find("tbWifi", pg) as TextBox).Text = req.Wifi.ToString();
            (FindControl.Find("tbWebcam", pg) as TextBox).Text = req.Webcam.ToString();
            (FindControl.Find("tbDateSubmitted", pg) as TextBox).Text = req.DateSubmitted;


            //If its a new request dont show these
            (FindControl.Find("pnlPeripheral", pg) as Panel).Visible = req.Status > 1;
            (FindControl.Find("pnlGVs", pg) as Panel).Visible = req.Status > 1;


            if (req.Type == 0)
                OrgRequest(pg, req as OrgRequest);
            else
                PersonalRequest(pg, req as PersonalRequest);
        }

        private static void OrgRequest(Page pg, OrgRequest req)
        {
            (FindControl.Find("lblRequestTypeInfo", pg) as Label).Text = "Org Request Info";
            (FindControl.Find("lblOne", pg) as Label).Text = "Contact Name:";
            (FindControl.Find("tbOne", pg) as TextBox).Text = req.ContactName;
            (FindControl.Find("lblTwo", pg) as Label).Text = "Contact Phone:";
            (FindControl.Find("tbTwo", pg) as TextBox).Text = req.ContactPhone;
            (FindControl.Find("lblThree", pg) as Label).Text = "Contact Email:";
            (FindControl.Find("tbThree", pg) as TextBox).Text = req.ContactEmail;
            (FindControl.Find("tbRequestPurpose", pg) as TextBox).Text = req.Purpose;
            (FindControl.Find("lblFour", pg) as Label).Visible = false;
            (FindControl.Find("tbFour", pg) as TextBox).Visible = false;
            (FindControl.Find("lblFive", pg) as Label).Text = "Timeline:";
            (FindControl.Find("tbFive", pg) as TextBox).Text = req.Timeline;
            (FindControl.Find("lblSix", pg) as Label).Text = "Items Requested:";
            (FindControl.Find("tbSix", pg) as TextBox).TextMode = TextBoxMode.MultiLine;
            (FindControl.Find("tbSix", pg) as TextBox).Text = req.ItemsRequested;



        }

        private static void PersonalRequest(Page pg, PersonalRequest req)
        {

        }
    }
}