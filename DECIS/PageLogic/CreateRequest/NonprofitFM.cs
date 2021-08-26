﻿using DECIS.DataAccess.DataAccessors.Documents;
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
            path = pg.Server.MapPath($"./Importing/Files/") + fu.FileName;
            fu.SaveAs(path);

        }

        public bool Verify()
        {
            return(fu.HasFile && CheckFile.Pdf(path));
        }

        public bool Upload(Organization org)
        {
            try
            {
                AmazonUploader myUploader = new AmazonUploader();
                Stream s = fu.PostedFile.InputStream;
                string[] fn = fu.FileName.Split('.');
                string key = $"{fn[0]}{org.OrgName}{DateTime.Today.ToString("MM-dd-yyyy")}.{fn[1]}"; //Add org name and todays date to files
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