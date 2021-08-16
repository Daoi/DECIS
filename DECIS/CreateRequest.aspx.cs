using DECIS.CotrolLogic.DDL;
using DECIS.PageLogic.CreateRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class CreateRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DropDownList> ddls = new List<DropDownList>() { ddlOrg };
                DDLDataBind.Bind(ddls);
            }
        }

        protected void ddlRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            RequestType.SetRequest(ddl, Page);
            upForm.Update();
        }
    }
}