using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    public class Model
    {
        public int ModelID { get; set; }
        public int MakeID { get; set; }
        public string Make { get; set; }
        public int AssetTypeID { get; set; }
        public string AssetType { get; set; }
        public string Image { get; set; }
        public string ModelName { get; set; }


        public Model()
        {

        }

        public Model(DataRow dr)
        {
            MakeID = int.Parse(dr["MakeID"].ToString());
            Make = dr["Make"].ToString();
            AssetTypeID = int.Parse(dr["AssetTypeID"].ToString());
            AssetType = dr["AssetType"].ToString();
            Image = dr["Image"].ToString();
            ModelName = dr["Model"].ToString();
        }
    }
}