using DECIS.ControlLogic.Gridview;
using DECIS.DataAccess.DataAccessors;
using DECIS.DataAccess.DataAccessors.Intake;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class IntakeList : System.Web.UI.Page
    {
        DataTable dtIntakeList;
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    HeaderBinding.CreateHeaders(gvIntakeList);
                    dtIntakeList = new GetAllIntakes().ExecuteCommand();

                    if (dtIntakeList.Rows.Count == 0)
                    {
                        lblGVMessage.Text = "Couldn't find any intakes to display.";
                        divNoRows.Visible = true;
                        return;
                    }
                    gvIntakeList.DataSource = dtIntakeList;
                    gvIntakeList.DataBind();

                    ViewState["IntakeListDT"] = dtIntakeList;
                }

                dtIntakeList = ViewState["IntakeListDT"] as DataTable;
        }

        protected void lnkBtnView_Click(object sender, EventArgs e)
        {
            //Get the row containing the clicked button
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            //Recreate the Datarow the GVR is bound to
            DataRow dr = (ViewState["IntakeListDT"] as DataTable).Rows[row.DataItemIndex];

            Response.Redirect($"./IntakeView.aspx?intid={dr["IntakeID"].ToString()}");
        }
    }
}