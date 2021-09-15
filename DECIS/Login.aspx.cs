using DECIS.Account;
using DECIS.DataAccess.DataAccessors.Account;
using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class Login : System.Web.UI.Page
    {
        AWSCognitoManager man;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["CognitoManager"] == null)
            {
                man = new AWSCognitoManager();
                Session["CognitoManager"] = man;
            }
            else
                man = Session["CognitoManager"] as AWSCognitoManager;

        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string pw = tbPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pw))
            {
                lblError.Visible = true;
                lblError.Text = "Fill out all fields.";
                return;
            }

            try
            {
                var authResponse = await man.SignInAsync(email, pw);

                if (authResponse != null)
                {
                    lblError.Text = "";

                    // get user data from db
                   User curUser = new User(new GetAccount().ExecuteCommand(tbEmail.Text).Rows[0]);
                    Session["User"] = curUser;
                    Session["CognitoManager"] = man;
                    Response.Redirect("./Homepage.aspx", false);

                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "An unknown error occurred. Please try again later.";
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
        }
    }
}