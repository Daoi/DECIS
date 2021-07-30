using DECIS.DataAccess.DataAccessors.Organization;
using DECIS.Importing;
using System;
using System.Collections.Generic;
using System.Data;
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
            if (!IsPostBack)
            {
                DataTable dtOrgs = new GetAllOrgs().ExecuteCommand();
                ddlOrgs.DataSource = dtOrgs;
                ddlOrgs.DataTextField = "OrgName";
                ddlOrgs.DataValueField = "OrgID";
                ddlOrgs.DataBind();
            }
        }

        protected void btnSubmitImport_Click(object sender, EventArgs e)
        {

            if (fileUpload.HasFile && FileIsValid(fileUpload))
            {
                try
                {
                    string path = Server.MapPath($"./Importing/Files/") + fileUpload.FileName;
                    fileUpload.SaveAs(path);

                    AssetImportReader import = new AssetImportReader(path, ddlOrgs.SelectedItem.Text);
                    lblInsertCount.Text = $"Added {import.assets.Count} of {import.Rows}";
                    lblMessage.Visible = true;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                    lblMessage.Visible = true;
                }
            }
        }

        private bool FileIsValid(FileUpload fileUpload)
        {
            return fileUpload.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // .xlsx file type
        }

    }
}