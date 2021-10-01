using DECIS.DataAccess.DataAccessors.Model;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.Settings
{
    public class BindGridViews
    {
        public static void Bind(Page pg)
        {
            GridView gv = FindControl.Find("gvModels", pg) as GridView;
            gv.DataSource = new GetAllModel().ExecuteCommand();
            gv.DataBind();
        }
    }
}