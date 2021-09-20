using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DECIS.ControlLogic.Gridview
{
    public class DataTableFilter
    {
        public static bool Filter(DataTable source, GridView target, Func<DataRow, bool> condition)
        {
            DataTable filteredDT;
            var result = source.AsEnumerable().Where(condition);
            if (Enumerable.Any(result))
            {
                filteredDT = result.CopyToDataTable();
                target.DataSource = filteredDT;
                target.DataBind();
                return true;
            }
            else
                return false;
        }
    }
}