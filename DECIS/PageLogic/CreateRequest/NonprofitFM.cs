using DECIS.DataAccess.DataAccessors.Documents;
using DECIS.DataModels;
using DECIS.Importing;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.CreateRequest
{
    public class NonprofitFM
    {
        private const string BUCKET = "elasticbeanstalk-us-east-2-848774509032";
        Page pg;
        FileUpload fu;
        string path;
        public NonprofitFM(Page pg, FileUpload fu)
        {
            this.pg = pg;
            this.fu = fu;
        }

        public bool Verify()
        {
            return(fu.HasFile && CheckFile.Pdf(fu));
        }

        public bool Upload(Organization org)
        {
            try
            {
                AmazonUploader myUploader = new AmazonUploader();
                Stream s = fu.PostedFile.InputStream;
                string key = $"{org.OrgName}{DateTime.Today.ToString("yyyy-MM-dd")}.pdf"; //Add org name and todays date to files
                string awsInfo;
                bool a = myUploader.UploadFileToS3Private(s, BUCKET, key, out awsInfo, "Documents");
                if (a)
                {
                    new InsertDocument().ExecuteCommand(awsInfo, org.OrgID);
                    return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                return false;
            }


        }
    }
}