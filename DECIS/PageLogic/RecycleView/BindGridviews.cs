using DECIS.DataAccess.DataAccessors.Assets;
using DECIS.DataAccess.DataAccessors.Recycle;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.RecycleView
{
    public class BindGridviews
    {
        public static void Bind(Page pg, int id)
        {
            if ((FindControl.Find("pnlGVs", pg) as Panel).Visible == false)
                return;
            //Controls
            GridView gvComputers = (FindControl.Find("gvComputers", pg) as GridView);
            GridView gvAssigned = (FindControl.Find("gvAssigned", pg) as GridView);
            //Asset List

            //Create Filters
            //Func<DataRow, bool> findComputers = r => r["Status"].ToString() == "Good" && (r["AssetType"].ToString() == "Computer" || r["AssetType"].ToString() == "Laptop");
            //Func<DataRow, bool> findMonitors = r => r["Status"].ToString() == "Good" && r["AssetType"].ToString() == "Monitor";
            //Func<DataRow, bool> findOther = r => r["Status"].ToString() == "Good" && (r["AssetType"].ToString() != "Monitor" || r["AssetType"].ToString() != "Computer" || r["AssetType"].ToString() != "Laptop");

            gvComputers.DataSource = new GetAllAssetsByStatus().ExecuteCommand(2);
            gvComputers.DataBind();
            gvAssigned.DataSource = new GetAllAssetsForRecycle().ExecuteCommand(id);
            gvAssigned.DataBind();

        }
    }
}