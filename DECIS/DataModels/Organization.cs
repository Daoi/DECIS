using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    public class Organization
    {
        public int OrgID { get; set; }
        public string OrgName { get; set; }
        public string OrgAddress { get; set; }
        public string OrgPhone { get; set; }
        public string OrgZipcode { get; set; }
        public string OrgEmail { get; set; }
        public string OrgContactPrimary { get; set; }
        public string OrgPrimaryPhone { get; set; }
        public string OrgPrimaryEmail { get; set; }
        public string OrgContactSecondary { get; set; }
        public string OrgSecondaryPhone { get; set; }
        public string OrgSecondaryEmail { get; set; }

        public Organization()
        {
        
        }

        public Organization(DataRow dr)
        {
            OrgID = int.Parse(dr["OrgId"].ToString());
            OrgName = dr["OrgName"].ToString();
            OrgAddress = dr["OrgAddress"].ToString(); 
            OrgPhone = dr["OrgPhone"].ToString();
            OrgZipcode = dr["OrgZipcode"].ToString();
            OrgEmail = dr["OrgEmail"].ToString();
            OrgContactPrimary = dr["OrgContactPrimary"].ToString();
            OrgPrimaryEmail = dr["OrgPrimaryEmail"].ToString();
            OrgPrimaryPhone = dr["OrgPrimaryPhone"].ToString();
            OrgContactSecondary = dr["OrgContactSecondary"].ToString();
            OrgSecondaryEmail = dr["OrgSecondaryEmail"].ToString();
            OrgSecondaryPhone = dr["OrgSecondaryPhone"].ToString();
        }

        public static Organization ImportOrg(DataRow dr)
        {
            Organization newOrg = new Organization()
            {
                OrgName = dr["Donor's Organization"].ToString(),
                OrgAddress = dr["Organization's Address"].ToString(),
                OrgPhone = dr["Phone Number"].ToString(),
                OrgZipcode = dr["Zip Code"].ToString(),
                OrgEmail = dr["Email Address"].ToString(),
                OrgContactPrimary = dr["Contact Person"].ToString(),
                OrgPrimaryEmail = dr["Email Address"].ToString(),
                OrgPrimaryPhone = dr["Phone Number"].ToString()
            };

            return newOrg;
        }

    }
}