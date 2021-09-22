using DECIS.DataAccess.DataAccessors.Person;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class PersonList : System.Web.UI.Page
    {
        DataTable dtPersonList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dtPersonList = new GetAllPeople().ExecuteCommand();

                if (dtPersonList.Rows.Count == 0)
                {
                    lblGVMessage.Text = "Couldn't find any people to display.";
                    divNoRows.Visible = true;
                    return;
                }
                gvPersonList.DataSource = dtPersonList;
                gvPersonList.DataBind();
                ViewState["PersonListDT"] = dtPersonList;
            }

            dtPersonList = ViewState["PersonListDT"] as DataTable;
        
        }

        protected void lnkBtnView_Click(object sender, EventArgs e)
        {
            //Get the row containing the clicked button
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            //Get the Datarow the GVR is bound to
            DataRow dr = dtPersonList.Rows[row.DataItemIndex];

            Response.Redirect($"./PersonView.aspx?pid={dr["PersonID"].ToString()}&dup={CheckDuplicates(dr.Field<string>("Phone")).ToString()}");

        }

        private bool CheckDuplicates(string phone) {

            var duplicates = dtPersonList.AsEnumerable()
                .GroupBy(r => r.Field<string>("Phone"))
                .Where(phoneGroup => phoneGroup.Count() > 1)
                .Select(group => group.Key);

            return duplicates.Contains(phone);
        }

    }
}