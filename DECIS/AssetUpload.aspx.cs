using DECIS.ControlLogic.Gridview;
using DECIS.DataAccess.DataAccessors.Organization;
using DECIS.DataModels;
using DECIS.Importing;
using DECIS.Utilities;
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
        AssetImportReader import;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtOrgs = new GetAllOrgs().ExecuteCommand();
                ddlOrgs.DataSource = dtOrgs;
                ddlOrgs.DataTextField = "OrgName";
                ddlOrgs.DataValueField = "OrgID";
                ddlOrgs.DataBind();
                gvDuplicates.Visible = false;
            }
            if(ViewState["Import"] != null)
                import = ViewState["Import"] as AssetImportReader;
        }

        protected void btnSubmitImport_Click(object sender, EventArgs e)
        {

            if (fileUpload.HasFile && CheckFile.Excel(fileUpload))
            {
                try
                {
                    string path = Server.MapPath($"./Importing/Files/") + fileUpload.FileName;
                    fileUpload.SaveAs(path);

                    import = new AssetImportReader(path, ddlOrgs.SelectedItem.Text);
                    ViewState["Import"] = import;
                    lblInsertCount.Text = $"Added {import.Successful} of {import.Rows} new Assets";
                    if (import.Duplicates.Count > 0)
                    {
                        lblInsertCount.Text += $"<br /> Found {import.Duplicates.Count} duplicate serial number(s): ";
                        gvDuplicates.Visible = true;
                        gvDuplicates.DataSource = import.Duplicates;
                        gvDuplicates.DataBind();
                        btnRetryImports.Visible = true;
                        upGV.Update();
                    }
                    else if (import.Duplicates.Count <= 0 && import.Successful <= 0)
                    {
                        import.Abort();
                        lblMessage.Text += $"<br /> No valid assets found, Intake aborted.";
                    }
                    lblMessage.Visible = true;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                    lblMessage.Visible = true;
                }
            }
        }

        protected void btnRetryImports_Click(object sender, EventArgs e)
        {
            List<Asset> retries = new List<Asset>();
            for (int row = 0; row < gvDuplicates.Rows.Count; row++)
            {
                CheckBox cb = (CheckBox)gvDuplicates.Rows[row].FindControl("cbSelectDupe");

                if (cb != null && cb.Checked)
                {
                    string sn = (gvDuplicates.Rows[row].FindControl("hfOriginalSerial") as HiddenField).Value; //Original SN
                    Asset selected = (Asset)import.Duplicates.Find(a => a.SerialNumber == sn).Clone();
                    selected.SerialNumber = (gvDuplicates.Rows[row].FindControl("tbSerialNumber") as TextBox).Text; //Update serial number
                    retries.Add(selected);
                }
            }

            import.HandleDuplicates(retries);

            if (import.Duplicates.Count != 0)
            {
                gvDuplicates.DataSource = import.Duplicates;
                gvDuplicates.DataBind();
                upGV.Update();
            }
            else
            {
                gvDuplicates.Visible = false;
                lblMessage.Text = "All duplicates fixed";
                lblInsertCount.Text = $"{import.Successful} Assets out of {import.Rows} imported";
                btnRetryImports.Visible = false;
                upGV.Update();
            }
        }
    }
}