using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DECIS.Utilities
{
    public class CheckFile
    {

        public static bool Image(FileUpload fileUpload)
        {
            return MimeMapping.GetMimeMapping(fileUpload.PostedFile.ContentType).StartsWith("image/", StringComparison.OrdinalIgnoreCase);
        }

        public static bool Excel(FileUpload fileUpload)
        {
            return fileUpload.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"; // .xlsx file type
        }

        public static bool Pdf(FileUpload fileUpload) 
        {
            string x = MimeMapping.GetMimeMapping(fileUpload.PostedFile.ContentType);
            return x.Contains("application/pdf") || x.Contains("application/octet-stream");
        }
    }
}