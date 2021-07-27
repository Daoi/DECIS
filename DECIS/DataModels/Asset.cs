using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    public class Asset
    {
        public int AssetID { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public string AssetType { get; set; }
        public string Location { get; set; }
        public int LocationID { get; set; }
        public string LocationDescription { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
        public string Make { get; set; }
        public int MakeID { get; set; }
        public string Model { get; set; }
        public int ModelID { get; set; }
        public string Image { get; set; }
        public int? IntakeID { get; set; } //Keep track of where item came from eventually
        public string OrgName { get; set; }

        public Asset()
        {
        }

        public Asset(DataRow dr)
        {
            AssetID = int.Parse(dr["AssetID"].ToString());
            SerialNumber = dr["SerialNumber"].ToString();
            Description = dr["Description"].ToString();
            AssetType = dr["AssetType"].ToString();
            Location = dr["Location"].ToString();
            LocationDescription = dr["LocationDescription"].ToString();
            Status = dr["Status"].ToString();
            Make = dr["Make"].ToString();
            Model = dr["Model"].ToString();
            Image = dr["Image"].ToString();
            MakeID = int.Parse(dr["MakeID"].ToString());
            IntakeID =  int.Parse(dr["Intake"].ToString());
            OrgName = dr["OrgName"].ToString();
        }
    }
}