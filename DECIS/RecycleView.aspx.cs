using DECIS.ControlLogic.Gridview;
using DECIS.ControlLogic.Panels;
using DECIS.DataAccess.DataAccessors.Assets;
using DECIS.DataModels;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class RecycleView : System.Web.UI.Page
    {
        int ID;
        List<int> assetsToAdd;
        List<int> assetsToRemove;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["id"], out ID))
                Response.Redirect("./RecycleList.aspx");


            HeaderBinding.CreateHeaders(new List<GridView>() { gvComputers, gvAssigned });

            if (!IsPostBack)
            {
                Session["Add"] = new List<int>();
                Session["Remove"] = new List<int>();
                Session["BadAssets"] = new GetAllAssetsByStatus().ExecuteCommand(2); // 2 = bad - Getting all bad assets
                try
                {

                }
                catch (Exception ex)
                {
                    Response.Redirect("./RecycleList.aspx");
                }

                TogglePanel.ToggleInputs(pnlControls);

            }
            int status = (ViewState["Recycle"] as Recycle).RecycleStatus;
            //If Finished(2) or Cancelled(3) disable editing
            if (status >= 1)
                btnEdit.Visible = false;

        }

        protected void btnAddAll_Click(object sender, EventArgs e)
        {
            if ((Session["Add"] as List<int>).Count == 0)
            {
                //Lbl error message none selected
                return;
            }
            else
                AddAssets.Add(Session["Add"] as List<int>, reqID);

            Response.Redirect($"./RequestView.aspx?reqid={reqID}&type={type}");
        }

        protected void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if ((Session["Remove"] as List<int>).Count == 0)
            {
                //Lbl error message none selected
                return;
            }
            else
                RemoveAssets.Remove(Session["Remove"] as List<int>, ID);

            Response.Redirect($"./RecycleView.aspx?id={ID}");
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
            if (ViewState["Editing"] != null && (bool)ViewState["Editing"]) //If we're in edit mode
            {
                //Save currently selected values
                Response.Redirect($"./RecycleView.aspx?id={ID}");
            }
            int status = (ViewState["Recycle"] as Recycle).RecycleStatus;
            //If Finished(2) or Cancelled(3)
            if (status >= 1)
                return;

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
            TogglePanel.ToggleInputs(pnlControls);
            TogglePanel.ToggleInputs(pnlPeripheral);
            TogglePanel.ToggleInputs(pnlDDLs);
            btnCancelEdit.Visible = false;
            btnEdit.Text = "Edit";
        }

    }
}