using DECIS.ControlLogic.Gridview;
using DECIS.DataAccess.DataAccessors.Recycle;
using DECIS.DataModels;
using DECIS.PageLogic.RecycleList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class RecycleList : System.Web.UI.Page
    {
        DataTable dtRecycleList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["User"] as User).Role != (int)Permission.Admin)
                Response.Redirect("~/Homepage.aspx");

            if (!IsPostBack)
            {
                dtRecycleList = new GetAllRecycle().ExecuteCommand();

                if (dtRecycleList.Rows.Count == 0)
                {
                    lblGVMessage.Text = "Couldn't find any intakes to display.";
                    pnlFilters.Visible = false;
                    divNoRows.Visible = true;

                    return;
                }
                gvRecycleList.DataSource = dtRecycleList;
                gvRecycleList.DataBind();

                ViewState["RecycleListDT"] = dtRecycleList;
            }

            dtRecycleList = ViewState["RecycleListDT"] as DataTable;
        }

        protected void lnkBtnView_Click(object sender, EventArgs e)
        {
            //Get the row containing the clicked button
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            DataRow dr;
            //Recreate the Datarow the GVR is bound to
            if (ViewState["Filter"] == null)
                dr = (ViewState["RecycleListDT"] as DataTable).Rows[row.DataItemIndex];
            else
                dr = (ViewState[$"{ViewState["Filter"].ToString()}"] as DataTable).Rows[row.DataItemIndex];

            Response.Redirect($"./RecycleView.aspx?id={dr["RecycleID"]}");
        }

        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            DataTable result = null;
            int status = 0;
            //Display
            gvRecycleList.Visible = true;
            lblGVMessage.Text = "";
            lblGVMessage.Visible = false;
            ViewState["Filter"] = lb.ID;
            //Filter 
            if (lb.ID == lbAll.ID)
            {
                gvRecycleList.DataSource = dtRecycleList;
                gvRecycleList.DataBind();
            }
            else
            {

                if (lb.ID == lbPending.ID)
                    status = 1;
                else if (lb.ID == lbFinished.ID)
                    status = 2;
                else if (lb.ID == lbCancelled.ID)
                    status = 3;

                if (ViewState[$"{lb.ID}"] == null)
                {
                    ViewState[$"{lb.ID}"] = new GetAllRecycleByStatus().ExecuteCommand(status);
                    result = ViewState[$"{lb.ID}"] as DataTable;
                }
                else
                    result = ViewState[$"{lb.ID}"] as DataTable;

                gvRecycleList.DataSource = result;
                gvRecycleList.DataBind();
            }
        }

        protected void btnCreateRecycle_Click(object sender, EventArgs e)
        {
            int newID = CreateNewRecycle.Create();
            if(newID != -1)
            {
                Response.Redirect($"./RecycleView.aspx?id={newID}");
            }
            else
            {
                lblNewRecycle.Text = "Couldn't create new Recycle Form, try again later.";
            }
        }
    }
}