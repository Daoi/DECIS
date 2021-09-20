using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    [Serializable]
    public class OrgRequest : Request
    {
        public int OrgRequestID { get; set; }
        public string Timeline { get; set; }
        public string ItemsRequested { get; set; }
        public string Purpose { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public OrgRequest(){}

        public OrgRequest(DataRow dr) : base(dr)
        {
            OrgRequestID = int.Parse(dr["OrgRequestID"].ToString());
            Purpose = dr["Purpose"].ToString();
            Timeline = dr["Timeline"].ToString();
            ItemsRequested = dr["ItemsRequested"].ToString();
            ContactEmail = dr["ContactEmail"].ToString();
            ContactPhone = dr["ContactPhone"].ToString();
            ContactName = dr["ContactName"].ToString();
        }
    }
}