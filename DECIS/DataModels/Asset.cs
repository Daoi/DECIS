using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    [Serializable]
    public class Asset : ICloneable
    {
        public int AssetID { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public string AssetType { get; set; }
        public int AssetTypeID { get; set; }
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
        public List<int> IntakeID { get; set; } //Keep track of where item came from eventually
        public string OrgName { get; set; }

        public Asset()
        {
            IntakeID = new List<int>();
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
            Image = dr["Image"].ToString() == "" ? "No Image Available" : dr["Image"].ToString();
            MakeID = dr["MakeID"] == DBNull.Value ? -1 : int.Parse(dr["MakeID"].ToString());
            if (dr["IntakeID"] != DBNull.Value)
                IntakeID = FormatIDs(dr);
            OrgName = dr["OrgName"].ToString();
        }

        private List<int> FormatIDs(DataRow dr) {
            List<int> ids = new List<int>();
            string[] values = dr["IntakeID"].ToString().Split(',');
            values.ToList().ForEach(v => ids.Add(int.Parse(v)));
            return ids;
        }

        /// <summary>
        /// Create shallow copy of asset
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Asset asset = (Asset)MemberwiseClone();
            return asset;
        }
    }
}