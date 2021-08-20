using DECIS.ControlLogic.Gridview;
using DECIS.ControlLogic.Panels;
using DECIS.DataAccess.DataAccessors.Request;
using DECIS.DataModels;
using DECIS.PageLogic.RequestView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class RequestView : System.Web.UI.Page
    {
        int reqID;
        int type; //0 = Org, 1 = Personal
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["reqid"], out reqID))
                Response.Redirect("./RequestList.aspx");
            if (ViewState["Type"] == null)
            {
                if (!int.TryParse(Request.QueryString["type"], out type))
                    Response.Redirect("./RequestList.aspx");
            }
            else
                type = (int)ViewState["Type"]; //Try to prevent people breaking the webpage by manually changing type, kind of dumb/pointless

            if (!IsPostBack)
            {
                ViewState["Type"] = type;
                try
                {
                    if (type == 0)
                    {
                        OrgRequest req = new OrgRequest(new GetRequestInfoByID().ExecuteCommand(reqID, type).Rows[0]);
                        ViewState["Request"] = req;
                        DisplayRequest.Display(Page, req);
                    }
                    else
                    {
                        PersonalRequest req = new PersonalRequest(new GetRequestInfoByID().ExecuteCommand(reqID, type).Rows[0]);
                        ViewState["Request"] = req;
                        DisplayRequest.Display(Page, req);
                    }
                }
                catch(Exception ex)
                {
                    Response.Redirect("./RequestList.aspx");
                }
                HeaderBinding.CreateHeaders(new List<GridView>() { gvComputers, gvMonitors, gvOther });
                TogglePanel.ToggleInputs(pnlControls);

            }
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ViewState["Editing"] != null && (bool)ViewState["Editing"]) //If we're in edit mode
            {
                //Save currently selected values
                Request orgReq = ViewState["Request"] as Request;
                if (orgReq.Type == 0)
                {
                    OrgRequest newReq = CreateOrgRequest.Create(Page, orgReq.OrgID);
                    new UpdateOrgRequest(newReq).ExecuteCommand();
                }
                Response.Redirect($"./RequestView.aspx?reqid={reqID}&type={type}");
            }
            
            //Initialize or update Editing State value
            ViewState["Editing"] = ViewState["Edting"] == null ? ViewState["Editing"] = true : !(bool)ViewState["Editing"];

            //Setup display
            TogglePanel.ToggleInputs(pnlControls);
            btnCancelEdit.Visible = !btnCancelEdit.Visible;
            btnEdit.Text = btnEdit.Text == "Edit" ? "Save" : "Edit";
        }

        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
            //Setup display
            TogglePanel.ToggleInputs(pnlControls, true);
            btnCancelEdit.Visible = false;
            btnEdit.Text = "Edit";
        }

        protected void btnViewOrg_Click(object sender, EventArgs e)
        {
            Request req = ViewState["Request"] as Request;
            Response.Redirect($"./OrgView.aspx?orgid={req.OrgID.ToString()}");
        }
    }
}