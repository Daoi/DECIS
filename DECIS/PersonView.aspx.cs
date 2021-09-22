using DECIS.ControlLogic.Panels;
using DECIS.CotrolLogic.DDL;
using DECIS.DataAccess.DataAccessors.Person;
using DECIS.DataModels;
using DECIS.PageLogic.PersonView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class PersonView : System.Web.UI.Page
    {
        int pid;
        Person p;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["pid"], out pid))
                Response.Redirect("./PersonList.aspx");
            if (Request.QueryString["dup"] == "True")
                lblDuplicate.Visible = true;

            if (!IsPostBack)
            {
                Person p = new Person(new GetPersonByID().ExecuteCommand(pid).Rows[0], false);
                DDLDataBind.Bind(new List<DropDownList>() { ddlAgeRange, ddlEthnicity, ddlGender, ddlRace });
                Display.DisplayPerson(Page, p);
                TogglePanel.ToggleInputs(pnlControls);
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ViewState["Editing"] != null && (bool)ViewState["Editing"]) //If we're in edit mode
            {
                //Save currently selected values

            }

            //Initialize or update Editing State value
            ViewState["Editing"] = ViewState["Edting"] == null ? ViewState["Editing"] = true : !(bool)ViewState["Editing"];

            //Setup display
            TogglePanel.ToggleInputs(pnlControls);
            btnCancelEdit.Visible = !btnCancelEdit.Visible;
            btnEdit.Text = btnEdit.Text == "Edit" ? "Save" : "Edit";
        }

        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
            //Setup display
            TogglePanel.ToggleInputs(pnlControls);
            btnCancelEdit.Visible = false;
            btnEdit.Text = "Edit";

        }
    }
}