using DECIS.ControlLogic.Gridview;
using DECIS.ControlLogic.Panels;
using DECIS.CotrolLogic.DDL;
using DECIS.DataAccess.DataAccessors.Assets;
using DECIS.DataAccess.DataAccessors.Recycle;
using DECIS.DataModels;
using DECIS.PageLogic.RecycleView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class RecycleView : System.Web.UI.Page
    {
        int rcID;
        List<int> assetsToAdd;
        List<int> assetsToRemove;
        User currentUser;
        Recycle currentRecycle;


        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["User"] as User).Role != (int)Permission.Admin)
                Response.Redirect("~/Homepage.aspx");

            if (!int.TryParse(Request.QueryString["id"], out rcID))
                Response.Redirect("./RecycleList.aspx");

            if (!IsPostBack)
            {
                ViewState["Editing"] = false;
                Session["Add"] = new List<int>();
                Session["Remove"] = new List<int>();
                try
                {
                    BindGridviews.Bind(Page, rcID);
                    currentRecycle = new Recycle(new GetRecycleByID().ExecuteCommand(rcID).Rows[0]);
                    ViewState["Recycle"] = currentRecycle;
                    DDLDataBind.Bind(new List<DropDownList>() { ddlRecycleStatus, ddlRecycleOrg });
                    Display.DisplayRecycle(Page, currentRecycle);
                }
                catch (Exception ex)
                {
                    Response.Redirect("./RecycleList.aspx");
                }

                currentRecycle = ViewState["currentRecycle"] as Recycle;
                TogglePanel.ToggleInputs(pnlControls);

            }
            int status = (ViewState["Recycle"] as Recycle).RecycleStatus;
            //If Finished(2) or Cancelled(3) disable editing
            if (status > 1 && (Session["User"] as User).Role != (int)Permission.Admin)
            {
                pnlButtons.Visible = false;
                gvComputers.Visible = false;
            }

        }

        protected void btnAddAll_Click(object sender, EventArgs e)
        {
            if ((Session["Add"] as List<int>).Count == 0)
            {
                //Lbl error message none selected
                return;
            }
            else
                AddAssets.Add(Session["Add"] as List<int>, rcID);

            Response.Redirect($"./RecycleView.aspx?id={rcID}");
        }

        protected void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if ((Session["Remove"] as List<int>).Count == 0)
            {
                //Lbl error message none selected
                return;
            }
            else
                RemoveAssets.Remove(Session["Remove"] as List<int>, rcID);

            Response.Redirect($"./RecycleView.aspx?id={rcID}");
        }

        protected void cbSelectedAdd_CheckedChanged(object sender, EventArgs e)
        {
            assetsToAdd = (List<int>)Session["Add"];

            CheckBox cb = (CheckBox)sender;
            int id = int.Parse((cb.Parent.FindControl("hfAssetID") as HiddenField).Value);

            if (cb.Checked && !assetsToAdd.Contains(id))
                assetsToAdd.Add(id);
            else if (!cb.Checked && assetsToAdd.Contains(id))
                assetsToAdd.Remove(id);

            Session["Add"] = assetsToAdd;

        }
        protected void cbSelectedRemove_CheckedChanged(object sender, EventArgs e)
        {
            assetsToRemove = (List<int>)Session["Remove"];

            CheckBox cb = (CheckBox)sender;
            int id = int.Parse((cb.Parent.FindControl("hfAssetIDR") as HiddenField).Value);

            if (cb.Checked && !assetsToRemove.Contains(id))
                assetsToRemove.Add(id);
            else if (!cb.Checked && assetsToRemove.Contains(id))
                assetsToRemove.Remove(id);

            Session["Remove"] = assetsToRemove;

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            if ((bool)ViewState["Editing"]) //If we're in edit mode we want to save when edit button is clicked
            {
                try
                {
                    Recycle newRecycle = CreateRecycle.Create(Page, rcID);
                    new UpdateRecycle(newRecycle).ExecuteCommand();
                    if (newRecycle.RecycleStatus == 2) //Finished
                        MoveAssets();
                    Response.Redirect($"./RecycleView.aspx?id={rcID}"); //Causes back button to work poorly when redirecting, should just reinitialize page
                }
                catch (Exception ex)
                {
                    lblComputerMsg.Text = ex.Message;
                    lblComputerMsg.Visible = true;
                }

            }

            int status = (ViewState["Recycle"] as Recycle).RecycleStatus;
            //If Finished(2) or Cancelled(3)
            if (status > 1 && (Session["User"] as User).Role != (int)Permission.Admin)
                return;

            //Initialize or update Editing State value
            ViewState["Editing"] = !(bool)ViewState["Editing"]; 

            //Setup display
            TogglePanel.ToggleInputs(pnlControls);
            btnCancelEdit.Visible = !btnCancelEdit.Visible;
            btnEdit.Text = btnEdit.Text == "Edit" ? "Save" : "Edit";
        }

        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
            //Setup display
            TogglePanel.ToggleInputs(pnlControls);
            ViewState["Editing"] = false;
            btnCancelEdit.Visible = false;
            btnEdit.Text = "Edit";
        }

        private void MoveAssets()
        {
            List<int> assetIDs = new GetAllAssetsForRecycle().ExecuteCommand(rcID)
                .Rows.OfType<DataRow>()
                .Select(dr => dr.Field<int>("AssetID"))
                .ToList();

            MoveAssetsByID.Move(assetIDs, 52);
        }
    }

}