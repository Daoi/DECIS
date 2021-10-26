using DECIS.DataAccess.DataAccessors.Request;
using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if((Session["User"] as User).Role == (int)Permission.Basic)
            {
                divSettings.Visible = false;
            }
            if (!IsPostBack)
            {
                DataTable requestListDT = new GetAllRequestByStatus().ExecuteCommand((int)RequestStatus.New);
                gvUpcoming.DataSource = requestListDT;
                gvUpcoming.DataBind();
                ViewState["RequestListDT"] = requestListDT;
            }
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {

        }

        protected void lnkBtnView_Click(object sender, EventArgs e)
        {
            //Get the row containing the clicked button
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            DataRow dr;
            //Recreate the Datarow the GVR is bound to
            if (ViewState["Filter"] == null)
                dr = (ViewState["RequestListDT"] as DataTable).Rows[row.DataItemIndex];
            else
                dr = (ViewState[$"{ViewState["Filter"].ToString()}"] as DataTable).Rows[row.DataItemIndex];

            Response.Redirect($"./RequestView.aspx?reqid={dr["RequestID"].ToString()}&type={dr["Type"].ToString()}");
        }
    }
}