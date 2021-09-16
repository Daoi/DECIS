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
    public partial class Verify : System.Web.UI.Page
    {
        string usr;
        string pwd;
        protected void Page_Load(object sender, EventArgs e)
        {
            // try to autofill username from email link
            if (Request.QueryString["usr"] != null && Request.QueryString["pwd"] != null)
            {
                usr = Request.QueryString["usr"];
                pwd = Request.Url.AbsoluteUri.Split(new string[] { "pwd=" }, StringSplitOptions.None)[1]; //AWS occasionally uses & in their temp passwords which breaks the querystring
            }
            else
            {
                Response.Redirect("./Login.aspx");
            }
        }

        protected async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text) || string.IsNullOrWhiteSpace(txtRetypePassword.Text))
            {
                lblError.Text = "Fill out all fields.";
                return;
            }

            if (txtNewPassword.Text != txtRetypePassword.Text)
            {
                lblError.Text = "New password does not match confirmation.";
                return;
            }

            // AWS Cognito Login
            AWSCognitoManager man = new AWSCognitoManager();

            try
            {
                // confirm user and change password
                var signUpResponse = await man.ConfirmSignUpAsync(usr, pwd, txtNewPassword.Text);

                // I haven't run into a scenario in which the previous method fails and doesn't throw an error, but just in case...
                if (signUpResponse == null) { lblError.Text = "An unknown error occurred. Please try again later."; }

                // automatically sign user in
                var authResponse = await man.SignInAsync(usr, txtNewPassword.Text);

                if (authResponse != null)
                {
                    lblError.Text = "";

                    // get user data from db
                    GetAccount accessor = new GetAccount();
                    User curUser = new User(new GetAccount().ExecuteCommand(usr).Rows[0]);
                    Session["User"] = curUser;
                    Session["CognitoManager"] = man;

                    Response.Redirect("./Homepage.aspx", false);
                }
                else
                {
                    lblError.Text = "An unknown error occurred. Please try again later.";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}