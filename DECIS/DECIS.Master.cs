using DECIS.Account;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["CognitoManager"] == null)
            {
                Session["CognitoManager"] = new AWSCognitoManager();
            }
        }

        protected void lnkBtnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}