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
            }
            else if(ddl.SelectedIndex == ORG)
            {
                (FindControl.FindNM("pnlPersonal", pg) as Panel).Visible = false;
                (FindControl.FindNM("pnlOrg", pg) as Panel).Visible = true;
            }
            else if (ddl.SelectedIndex == NONE)
            {
                (FindControl.FindNM("pnlPersonal", pg) as Panel).Visible = false;
                (FindControl.FindNM("pnlOrg", pg) as Panel).Visible = false;
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