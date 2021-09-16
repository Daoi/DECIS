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
            //Recreate the Datarow the GVR is bound to
            DataRow dr = (ViewState["RecycleListDT"] as DataTable).Rows[row.DataItemIndex];

            Response.Redirect($"./RecycleView.aspx?id={dr["RecycleID"].ToString()}");
        }

        protected void lb_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            //Display
            bool result = true;
            gvRecycleList.Visible = true;
            lblGVMessage.Text = "";
            lblGVMessage.Visible = false;
            //Filter 
            if (lb.ID == lbAll.ID)
            {
                gvRecycleList.DataSource = dtRecycleList;
                gvRecycleList.DataBind();
            }
            else if (lb.ID == lbCancelled.ID)
                result = DataTableFilter.Filter(dtRecycleList, gvRecycleList, r => r["StatusText"].ToString() == "Cancelled");
            else if (lb.ID == lbPending.ID)
                result = DataTableFilter.Filter(dtRecycleList, gvRecycleList, r => r["StatusText"].ToString() == "Pending");
            else if (lb.ID == lbFinished.ID)
                result = DataTableFilter.Filter(dtRecycleList, gvRecycleList, r => r["StatusText"].ToString() == "Finished");
            //Didn't find anything that matched
            if (!result)
            {
                lblGVMessage.Visible = true;
                lblGVMessage.Text = $"Couldn't find any recycle reports with status {lb.Text}";
                gvRecycleList.Visible = false;
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