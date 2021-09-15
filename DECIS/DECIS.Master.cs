using DECIS.Account;
using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class DECIS : System.Web.UI.MasterPage
    {
        User currentUser;
        AWSCognitoManager man;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["CognitoManager"] == null || Session["User"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                currentUser = Session["User"] as User;
                man = Session["CognitoManager"] as AWSCognitoManager;
            }
        }

        protected void lnkBtnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}