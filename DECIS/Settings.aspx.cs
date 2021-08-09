using DECIS.CotrolLogic;
using DECIS.DataAccess.DataAccessors.Model;
using DECIS.DataModels;
using DECIS.Importing;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class Settings : System.Web.UI.Page
    {
        private string bucketImages = "decisimages";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DropDownList> ddls = new List<DropDownList>() { ddlAssetType, ddlAssetMake };
                DataSet dts = DDLDataBind.ddlBind(ddls);
            }
        }

        protected void btnAddModel_Click(object sender, EventArgs e)
        {
            Stream s = fuModelImage.PostedFile.InputStream;
            string[] image = fuModelImage.FileName.Split('.');
            string imageName = $"{image[0]}{RandomizeString.RandomString(5)}.{image[1]}"; //Try to prevent duplicate names
            AmazonUploader myUploader = new AmazonUploader();
            string url;
            bool a = myUploader.UploadFileToS3Public(s, bucketImages, imageName, out url, "Images");
            if (a)
            {
                Model mdl = new Model()
                {
                    ModelName = tbModelName.Text,
                    AssetType = ddlAssetType.SelectedItem.Text,
                    AssetTypeID = int.Parse(ddlAssetType.SelectedValue),
                    Make = ddlAssetMake.SelectedItem.Text,
                    MakeID = int.Parse(ddlAssetMake.SelectedValue),
                    Image = url
                };
                try
                {
                    int x = new InsertModel().ExecuteCommand(mdl);
                }
                catch (Exception ex)
                {
                    lblModelError.Text = ex.Message;
                    upModel.Update();
                }
            }

        }

        /// <summary>
        /// Make sure file is actually an image
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        private bool FileIsValid(FileUpload fileUpload)
        {
            return  MimeMapping.GetMimeMapping(fileUpload.PostedFile.ContentType).StartsWith("image/", StringComparison.OrdinalIgnoreCase);
        }

    }
}