using DECIS.Importing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class AssetUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitImport_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath($"./Importing/Files/") + "Donor Intake Sheet.xlsx";
            new AssetImportReader(path); 
        }

    }
}