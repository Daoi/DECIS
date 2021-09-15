using DECIS.Account;
using DECIS.CotrolLogic.DDL;
using DECIS.DataAccess.DataAccessors.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDLDataBind.Bind(new List<DropDownList>() { ddlRole });
            }
        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
                    
            AWSCognitoManager man = (AWSCognitoManager)Session["CognitoManager"];

            try
            {

                var res = await man.CreateUserAsync(tbEmail.Text, tbEmail.Text, int.Parse(ddlRole.SelectedValue));

                if (res != null)
                {
                    //Create new account
                    new InsertAccount().ExecuteCommand(tbEmail.Text, tbFirstName.Text, tbLastName.Text, int.Parse(ddlRole.SelectedValue));
                    lblError.Text = $"Account with email {tbEmail.Text} created succesfully.";
                }
                else
                {
                    throw new TimeoutException("An unknown error occurred. Please try again later.");
                }
                    
            }
            catch (Amazon.CognitoIdentityProvider.Model.UsernameExistsException ex)
            {
                lblError.Text = "An account with that email already exists.";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.ToString();
            }
        }
    }
}
