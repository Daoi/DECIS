using DECIS.DataAccess.DataAccessors.Documents;
using DECIS.DataModels;
using DECIS.Importing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.PageLogic.OrgView
{
    public class DownloadOrgDocuments
    {
        public static void Download(Organization org)
        {
            try
            {
                string path = new GetDocumentsByOrgID().ExecuteCommand(org.OrgID).Rows[0]["AwsInfo"].ToString();
                string url = AmazonUploader.GetURL(path);
                HttpContext.Current.Response.Redirect(url);
            }
            catch(Exception ex)
            {
                string a = ex.Message;
            }
        }
    }
}