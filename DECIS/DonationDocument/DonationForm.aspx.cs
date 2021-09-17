using DECIS.DataAccess.DataAccessors;
using DECIS.DataAccess.DataAccessors.Donations;
using DECIS.PageLogic.DonationForm;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.DonationDocument
{
    public partial class DonationForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int requestID;
            int type;

            if (!int.TryParse(Request.QueryString["id"], out requestID))
                Response.Redirect("../RequestList.aspx");
            if (!int.TryParse(Request.QueryString["type"], out type))
                Response.Redirect("../RequestList.aspx");

            if (!IsPostBack)
            {
                gvEquipment.DataSource = new GetDonationReleaseFormAssets().ExecuteCommand(requestID);
                gvEquipment.DataBind();
                Display.DisplayData(Page, requestID, type);
            }



        }

    }
}