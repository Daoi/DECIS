using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    [Serializable]
    public class Recycle
    {
        public string Recycler { get; set; }
        public string Date { get; set; }
        public int RecycleID { get; set; }
        public int RecycleReceiver { get; set; }
        public string RecycleOrgName { get; set; }
        public int RecycleStatus { get; set; }
        public string StatusText { get; set; }
        public Recycle() { }

        public Recycle(DataRow dr)
        {
            RecycleID = int.Parse(dr["RecycleID"].ToString());
            Recycler = dr["Recycler"].ToString();
            Date = dr["RecycleDate"].ToString();
            RecycleStatus = int.Parse(dr["RecycleStatus"].ToString());
            RecycleReceiver = int.Parse(dr["RecycleReceiver"].ToString());
            RecycleOrgName = dr["RecycleOrgName"].ToString();
            StatusText = dr["RecycleStatusT"].ToString();
        }

    }
}