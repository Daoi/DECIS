using DECIS.ControlLogic.Gridview;
using DECIS.DataAccess.DataAccessors.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class RequestList : System.Web.UI.Page
    {
        DataTable dtRequestList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtRequestList = new GetAllRequests().ExecuteCommand();

                if (dtRequestList.Rows.Count == 0)
                {
                    lblGVMessage.Text = "Couldn't find any intakes to display.";
                    divNoRows.Visible = true;
                    return;
                }
                gvRequestList.DataSource = dtRequestList;
                gvRequestList.DataBind();

                ViewState["RequestListDT"] = dtRequestList;
            }

            dtRequestList = ViewState["RequestListDT"] as DataTable;
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


        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            DataTable result = null;
            int status = 0;
            //Display
            gvRequestList.Visible = true;
            lblGVMessage.Text = "";
            lblGVMessage.Visible = false;
            ViewState["Filter"] = lb.ID;
            //Filter 
            if (lb.ID == lbAll.ID)
            {
                gvRequestList.DataSource = dtRequestList;
                gvRequestList.DataBind();
            }
            else { 
                if (lb.ID == lbNew.ID)
                    status = 1;
                else if (lb.ID == lbPending.ID)
                    status = 2;
                else if (lb.ID == lbScheduled.ID)
                    status = 3;
                else if (lb.ID == lbFinished.ID)
                    status = 4;
                else if (lb.ID == lbCancelled.ID)
                    status = 5;

                if (ViewState[$"{lb.ID}"] == null)
                {
                    ViewState[$"{lb.ID}"] = new GetAllRequestByStatus().ExecuteCommand(status);
                    result = ViewState[$"{lb.ID}"] as DataTable;
                }
                else
                    result = ViewState[$"{lb.ID}"] as DataTable;

                gvRequestList.DataSource = result;
                gvRequestList.DataBind();
            }

            if (result == null || result.Rows.Count == 0)
            {
                lblGVMessage.Visible = true;
                lblGVMessage.Text = $"Couldn't find any requests with status {lb.Text}";
                gvRequestList.Visible = false;
            }
        }
    }
}