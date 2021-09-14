using DECIS.DataAccess.DataAccessors;
using PuppeteerSharp;
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
    public partial class DonationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Flag"] = false;
                gvEquipment.DataSource = new GetAllAssets().ExecuteCommand().Rows.OfType<DataRow>().ToList().Take(10).CopyToDataTable();
                gvEquipment.DataBind();

            }



        }

    }
}