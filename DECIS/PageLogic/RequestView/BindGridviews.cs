using DECIS.ControlLogic.Gridview;
using DECIS.DataAccess.DataAccessors;
using DECIS.DataAccess.DataAccessors.Request;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.RequestView
{
    public class BindGridviews
    {

        public static void Bind(Page pg, int reqID)
        {
            if ((FindControl.Find("pnlGVs", pg) as Panel).Visible == false)
                return;
            //Controls
            GridView gvComputers = (FindControl.Find("gvComputers", pg) as GridView);
            GridView gvAssigned = (FindControl.Find("gvAssigned", pg) as GridView);
            //Asset List
            DataTable assets = HttpContext.Current.Session["AssetListDT"] as DataTable;

            //Create Filters
            //Func<DataRow, bool> findComputers = r => r["Status"].ToString() == "Good" && (r["AssetType"].ToString() == "Computer" || r["AssetType"].ToString() == "Laptop");
            //Func<DataRow, bool> findMonitors = r => r["Status"].ToString() == "Good" && r["AssetType"].ToString() == "Monitor";
            //Func<DataRow, bool> findOther = r => r["Status"].ToString() == "Good" && (r["AssetType"].ToString() != "Monitor" || r["AssetType"].ToString() != "Computer" || r["AssetType"].ToString() != "Laptop");

            DataTableFilter.Filter(assets, gvComputers, r => r["Status"].ToString() == "Good");
            gvAssigned.DataSource = new GetAllAssetsForRequest().ExecuteCommand(reqID);
            gvAssigned.DataBind();


            
        }
    }
}