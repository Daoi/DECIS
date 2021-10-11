using DECIS.Account;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.Login
{
    public class CodeConfirm
    {
        public async static void ConfirmCode(Page pg, AWSCognitoManager man, PanelLogic pl)
        {
            Panel pnlLogin = FindControl.FindNM("pnlLogin", pg) as Panel;
            Panel pnlPasswordReset = FindControl.FindNM("pnlPasswordReset", pg) as Panel;

            Label lblPRError = FindControl.FindNM("lblPRError", pg) as Label;
            Label lblPRInstructions = FindControl.FindNM("lblPRInstructions", pg) as Label;
            Label lblError = FindControl.FindNM("lblError", pg) as Label;
            Label lblInstructions = FindControl.FindNM("lblInstructions", pg) as Label;

            Button btnPRConfirm = FindControl.FindNM("btnPRConfirm", pg) as Button;
            Button btnPRSendCode = FindControl.FindNM("btnPRSendCode", pg) as Button;

            TextBox txtPRUsername = FindControl.FindNM("txtPRUsername", pg) as TextBox;
            TextBox txtPRVerificationCode = FindControl.FindNM("txtPRVerificationCode", pg) as TextBox;
            TextBox txtPRRetypePassword = FindControl.FindNM("txtPRRetypePassword", pg) as TextBox;
            TextBox txtPRNewPassword = FindControl.FindNM("txtPRNewPassword", pg) as TextBox;

            // check for empty textboxes
            if (pnlPasswordReset.Controls.OfType<TextBox>().ToList().Any(tb => string.IsNullOrWhiteSpace(tb.Text)))
            {
                lblPRError.Visible = true;
                lblPRError.Text = "Fill out all fields.";
                return;
            }

            if (txtPRNewPassword.Text != txtPRRetypePassword.Text)
            {
                lblPRError.Visible = true;
                lblPRError.Text = "New password does not match confirmation.";
                return;
            }

            if (!(txtPRNewPassword.Text.Length >= 12) || !(txtPRNewPassword.Text.Any(ch => char.IsUpper(ch)) && txtPRNewPassword.Text.Any(ch => char.IsLower(ch)) ) )
            {
                lblPRError.Visible = true;
                lblPRError.Text = "Passwords have a minimum length of 12 and must contain at leas one upper and lower case character.";
                return;
            }

            try
            {
                await man.ChangePasswordAsync(txtPRUsername.Text, txtPRNewPassword.Text, txtPRVerificationCode.Text);

                // send to login panel
                pl.ClearPasswordResetPanel();
                pnlLogin.Visible = true;
                lblInstructions.Text = "Password changed successfully! Please login.";
            }
            catch (Exception ex)
            {
                lblPRError.Visible = true;
                lblPRError.Text = ex.Message;
            }
        }
    }
}