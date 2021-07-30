using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DECIS.ControlLogic.FileUp
{
    public class ValidateFile
    {
        public static bool Validate(FileUpload fileUpload)
        {
            return fileUpload.PostedFile.ContentType == "application/vnd.ms-excel" && fileUpload.HasFile; //Make sure theres a CSV file selected

        }

    }
}