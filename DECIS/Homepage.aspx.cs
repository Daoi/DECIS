using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if((Session["User"] as User).Role == (int)Permission.Basic)
            {
                divSettings.Visible = false;
            }
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {

        }
    }
}