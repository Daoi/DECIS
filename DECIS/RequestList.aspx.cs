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
            //Recreate the Datarow the GVR is bound to
            DataRow dr = (ViewState["RequestListDT"] as DataTable).Rows[row.DataItemIndex];

            Response.Redirect($"./RequestView.aspx?reqid={dr["RequestID"].ToString()}&type={dr["Type"].ToString()}");
        }


        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            //Display
            bool result = true;
            gvRequestList.Visible = true;
            lblGVMessage.Text = "";
            lblGVMessage.Visible = false;
            //Filter 
            if (lb.ID == lbAll.ID )
            {
                gvRequestList.DataSource = dtRequestList;
                gvRequestList.DataBind();
            }
            else if(lb.ID == lbNew.ID)
                result = DataTableFilter.Filter(dtRequestList, gvRequestList, r => r["RequestStatus"].ToString() == "New");
            else if(lb.ID == lbPending.ID)
                result = DataTableFilter.Filter(dtRequestList, gvRequestList, r => r["RequestStatus"].ToString() == "Pending");
            else if(lb.ID == lbScheduled.ID)
                result = DataTableFilter.Filter(dtRequestList, gvRequestList, r => r["RequestStatus"].ToString() == "Scheduled");
            else if(lb.ID == lbFinished.ID)
                result = DataTableFilter.Filter(dtRequestList, gvRequestList, r => r["RequestStatus"].ToString() == "Finished");
            else
                result = DataTableFilter.Filter(dtRequestList, gvRequestList, r => r["RequestStatus"].ToString() == "Cancelled");
            //Didn't find anything that matched
            if (!result)
            {
                lblGVMessage.Visible = true;
                lblGVMessage.Text = $"Couldn't find any requests with status {lb.Text}";
                gvRequestList.Visible = false;
            }
        }
    }
}