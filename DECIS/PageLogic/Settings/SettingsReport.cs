using DECIS.DataAccess.DataAccessors.Reports;
using DECIS.Utilities;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.Settings
{
    public class SettingsReport
    {
        public static int Report(Page pg)
        {
            TextBox tbStartDate = FindControl.Find("tbStartDate", pg) as TextBox;
            TextBox tbEndDate = FindControl.Find("tbEndDate", pg) as TextBox;
            DateTime start;
            DateTime end;

            if (!DateTime.TryParse(tbStartDate.Text, out start) || !DateTime.TryParse(tbEndDate.Text, out end))
                return -1;
            else if (start > end)
            {
                throw new ArgumentException("Start Date must be before end date");
            }

            var personalReport = new GetPersonalRequestReport().ExecuteCommand(start, end);
            var orgReport = new GetOrgRequestReport().ExecuteCommand(start, end);

            GridView gvPersonalReport = FindControl.Find("gvPersonalReport", pg) as GridView;
            GridView gvOrganizationReport = FindControl.Find("gvOrganizationReport", pg) as GridView;

            gvPersonalReport.DataSource = personalReport;
            gvPersonalReport.DataBind();

            gvOrganizationReport.DataSource = orgReport;
            gvOrganizationReport.DataBind();

            return -1;
        }
    }
}