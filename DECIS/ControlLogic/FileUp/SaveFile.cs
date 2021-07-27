using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace DECIS.ControlLogic.FileUp
{
    public class SaveFile
    {
        public static string Save(FileUpload fileUpload)
        {
            StringBuilder sb = new StringBuilder();

            if (fileUpload.HasFile && ValidateFile.Validate(fileUpload))
            {
                try
                {
                    sb.Append($" Uploading file: {fileUpload.FileName}");

                    //saving the file
                    string path = HttpContext.Current.Server.MapPath($"./Importing/Files/") + fileUpload.FileName;
                    fileUpload.SaveAs(path);
                    //ReadFile(path);
                    return "";
                }
                catch (Exception ex)
                {
                    sb.Append($"Error uploading file: {ex.Message}.");
                    return sb.ToString();
                }
            }
            else
            {
                return "Invalid file format.";
            }
        }

    }
}