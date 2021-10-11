using DECIS.Account;
using DECIS.DataAccess.DataAccessors.Account;
using DECIS.DataModels;
using DECIS.PageLogic.Login;
using System;
using System.Web.UI;

namespace DECIS
{
    public partial class Login : Page
    {
        AWSCognitoManager man;
        PanelLogic pl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["PaneLogic"] != null)
                pl = Session["PanelLogic"] as PanelLogic;
            else
            {
                pl = new PanelLogic(Page);
                Session["PanelLogic"] = pl;
            }

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

        protected void switchPanels(object sender, EventArgs e)
        {
            if (pnlLogin.Visible)
            {
                pl.ClearLoginPanel();
                pnlPasswordReset.Visible = true;
            }
            else
            {
                pl.ClearPasswordResetPanel();
                pnlLogin.Visible = true;
            }
        }


        // request verification code
        protected async void btnPRSendCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPRUsername.Text))
            {
                lblPRError.Visible = true;
                lblPRError.Text = "Enter your Username.";
                return;
            }

            try
            {
                await man.SendForgotPasswordCodeAsync(txtPRUsername.Text);

                pl.SetUpPasswordResetPanel();// enable the rest of the controls
            }
            catch (Exception ex)
            {
                lblPRError.Visible = true;
                lblPRError.Text = ex.Message;
            }
        }

        // change password
        protected async void btnPRConfirm_Click(object sender, EventArgs e)
        {
            CodeConfirm.ConfirmCode(Page, man, pl);
        }

    }
}