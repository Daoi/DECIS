using DECIS.CotrolLogic.DDL;
using DECIS.PageLogic.CreateRequest;
using DECIS.Utilities;
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

            }
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            if (ddl.ID == ddlRequestType.ID)
            {
                RequestType.SetRequest(ddl, Page);
                ViewState["Type"] = ddlRequestType.SelectedValue;
            }
            else if (ddl.ID == ddlOrg.ID && ddlRequestType.SelectedValue == "Organization")//If its an org request type
            {
                ViewState["SelectedOrg"] = DisplayInfo.DisplayOrgInfo(ddl.SelectedValue, Page);
            }
            else if (ddl.ID == ddlOrg.ID && ddlRequestType.SelectedValue == "Personal")//If its a personal request type
            {
                ViewState["SelectedOrg"] =  DisplayInfo.DisplayOrgInfo(ddl.SelectedValue, Page, true);
            }

            upForm.Update();
        }

        protected void cbSameAsRequester_CheckedChanged(object sender, EventArgs e)
        {
            SameAsRequestor.Fill((CheckBox)sender, Page);
            upForm.Update();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string requestType = ViewState["Type"].ToString();
            upForm.Update();
            if (requestType == "Organization")
            {
                try
                {
                    NonprofitFM fm = new NonprofitFM(Page, fuDocuments);
                    if (fm.Verify())
                    {
                        CollectOrgRequestInfo.Collect(Page, ddlOrg.SelectedValue != "-1");
                    }
                    else
                    {
                        lblSubmitError.Text = "You must upload a valid PDF file";
                        return;
                    }

                }
                catch (Exception ex)
                {
                    lblSubmitError.Text = ex.Message;
                }
            }
        }
    }
}