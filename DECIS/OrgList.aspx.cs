using DECIS.ControlLogic.Gridview;
using DECIS.DataAccess.DataAccessors.Organization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class OrgList : Page
    {
        DataTable dtOrgList; 
        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    dtOrgList = new GetAllOrgs().ExecuteCommand();

                    if (dtOrgList.Rows.Count == 0)
                    {
                        lblGVMessage.Text = "Couldn't find any orgs to display.";
                        divNoRows.Visible = true;
                        return;
                    }
                    gvOrgList.DataSource = dtOrgList;
                    gvOrgList.DataBind();
                    ViewState["OrgListDT"] = dtOrgList;
                }
                dtOrgList = ViewState["OrgListDT"] as DataTable;
        }



        protected void lnkBtnView_Click(object sender, EventArgs e)
        {
            //Get the row containing the clicked button
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            //Get the Datarow the GVR is bound to
            DataRow dr = (ViewState["OrgListDT"] as DataTable).Rows[row.DataItemIndex];

            Response.Redirect($"./OrgView.aspx?orgid={dr["OrgID"].ToString()}");
        }
    }
}