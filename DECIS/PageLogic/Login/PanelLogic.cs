using DECIS.ControlLogic.Panels;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.Login
{
    public class PanelLogic
    {
        Panel pnlLogin;
        Panel pnlPasswordReset;

        Label lblPRError;
        Label lblPRInstructions;
        Label lblError;
        Label lblInstructions;

        Button btnPRConfirm;
        Button btnPRSendCode;

        TextBox txtPRUsername;
        TextBox txtPRVerificationCode;
        TextBox txtPRRetypePassword;
        TextBox txtPRNewPassword;

        public PanelLogic(Page pg)
        {
            pnlLogin = FindControl.FindNM("pnlLogin", pg) as Panel;
            pnlPasswordReset = FindControl.FindNM("pnlPasswordReset", pg) as Panel;

            lblPRError = FindControl.FindNM("lblPRError", pg) as Label;
            lblPRInstructions = FindControl.FindNM("lblPRInstructions", pg) as Label;
            lblError = FindControl.FindNM("lblError", pg) as Label;
            lblInstructions = FindControl.FindNM("lblInstructions", pg) as Label;

            btnPRConfirm = FindControl.FindNM("btnPRConfirm", pg) as Button;
            btnPRSendCode = FindControl.FindNM("btnPRSendCode", pg) as Button;

            txtPRUsername = FindControl.FindNM("txtPRUsername", pg) as TextBox;
            txtPRVerificationCode = FindControl.FindNM("txtPRVerificationCode", pg) as TextBox;
            txtPRRetypePassword = FindControl.FindNM("txtPRRetypePassword", pg) as TextBox;
            txtPRNewPassword = FindControl.FindNM("txtPRNewPassword", pg) as TextBox;
        }

        public void ClearLoginPanel()
        {
            pnlLogin.Visible = false;
            lblError.Text = "";
            lblInstructions.Text = "Enter your username and password.";

            ClearPanel.ClearTBs(new List<Panel> { pnlLogin });
        }

        public void ClearPasswordResetPanel()
        {
            pnlPasswordReset.Visible = false;

            txtPRVerificationCode.Enabled = false;
            txtPRNewPassword.Enabled = false;
            txtPRRetypePassword.Enabled = false;

            btnPRConfirm.Enabled = false;
            btnPRConfirm.CssClass = btnPRConfirm.CssClass.Replace("btn-primary", "btn-secondary");

            btnPRSendCode.Text = "Send Code";

            lblPRError.Text = "";
            lblPRInstructions.Text = "Enter your username to email your verification code.";

            ClearPanel.ClearTBs(new List<Panel> { pnlPasswordReset });
        }

        // use to enable controls after verification code is sent
        public void SetUpPasswordResetPanel()
        {
            txtPRVerificationCode.Enabled = true;
            txtPRNewPassword.Enabled = true;
            txtPRRetypePassword.Enabled = true;

            btnPRConfirm.Enabled = true;
            btnPRConfirm.CssClass = btnPRConfirm.CssClass.Replace("btn-secondary", "btn-primary");

            btnPRSendCode.Text = "Resend Code";

            lblPRError.Text = "";
            lblPRInstructions.Text = "Check your email for code, then enter a new password.";
        }

    }
}