using DECIS.CotrolLogic.DDL;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.CreateRequest
{
    public class RequestType
    {
        const int NONE = 0;
        const int PERSONAL = 1;
        const int ORG = 2;

        public static void SetRequest(DropDownList ddl, Page pg)
        {
            DropDownList ddlOrg = (FindControl.FindNM("ddlOrg", pg) as DropDownList);
            Label lblOrg = (FindControl.FindNM("lblOrganization", pg) as Label);

            if (ddl.SelectedIndex == PERSONAL)
            {
                (FindControl.FindNM("pnlPersonal", pg) as Panel).Visible = true;
                (FindControl.FindNM("pnlOrg", pg) as Panel).Visible = false;
                (FindControl.FindNM("fuDocuments", pg) as FileUpload).Visible = false;
                (FindControl.FindNM("lblFU", pg) as Label).Visible = false;
                (FindControl.FindNM("lblAddress", pg) as TextBox).Visible = false;
                (FindControl.FindNM("tbAddress", pg) as TextBox).Visible = false;
                (FindControl.FindNM("lblZipcode", pg) as TextBox).Text = "Zip Code of Primary Residence:";

            }
            else if(ddl.SelectedIndex == ORG)
            {
                (FindControl.FindNM("pnlPersonal", pg) as Panel).Visible = false;
                (FindControl.FindNM("pnlOrg", pg) as Panel).Visible = true;
                (FindControl.FindNM("fuDocuments", pg) as FileUpload).Visible = true;
                (FindControl.FindNM("lblFU", pg) as Label).Visible = true;
                (FindControl.FindNM("lblAddress", pg) as TextBox).Visible = true;
                (FindControl.FindNM("tbAddress", pg) as TextBox).Visible = true;
                (FindControl.FindNM("lblZipcode", pg) as TextBox).Text = "Organization Zip Code:";

            }
            else if (ddl.SelectedIndex == NONE)
            {
                (FindControl.FindNM("pnlPersonal", pg) as Panel).Visible = false;
                (FindControl.FindNM("pnlOrg", pg) as Panel).Visible = false;
                (FindControl.FindNM("fuDocuments", pg) as FileUpload).Visible = false;
                (FindControl.FindNM("lblFU", pg) as Label).Visible = false;
                ddlOrg.Visible = false;
                lblOrg.Visible = false;
                return;
            }

            ddlOrg.Visible = true;
            lblOrg.Visible = true;
            List<DropDownList> ddls = new List<DropDownList>() { ddlOrg };
            DDLDataBind.Bind(ddls);
        }
    }
}