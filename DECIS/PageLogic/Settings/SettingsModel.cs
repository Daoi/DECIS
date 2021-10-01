using DECIS.DataAccess.DataAccessors.Model;
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

namespace DECIS.PageLogic.Settings
{
    public class SettingsModel
    {
        private static string bucketImages = "decisimages";

        public static int Add(Page pg)
        {
            //Find Controls
            FileUpload fuModelImage = FindControl.Find("fuModelImage", pg) as FileUpload;
            Label lblModelMsg = FindControl.Find("lblModelMsg", pg) as Label;
            UpdatePanel upModel = FindControl.Find("upModel", pg) as UpdatePanel;

            if (!fuModelImage.HasFile)
            {
                lblModelMsg.Text = "Must upload an image file to add a model.";
                upModel.Update();
                return -1;
            }
            TextBox tbModelName = FindControl.Find("tbModelName", pg) as TextBox;
            DropDownList ddlAssetType = FindControl.Find("ddlAssetType", pg) as DropDownList;
            DropDownList ddlAssetMake = FindControl.Find("ddlAssetMake", pg) as DropDownList;

            Stream s = fuModelImage.PostedFile.InputStream;
            string[] image = fuModelImage.FileName.Split('.');
            string imageName = $"{tbModelName.Text}{DateTime.Today.ToShortDateString().Replace("/", "")}.{image[1]}"; //Try to prevent duplicate names
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
                    lblModelMsg.Text = $"Succesfully added {mdl.ModelName}";
                    upModel.Update();
                    return x;
                }
                catch (Exception ex)
                {
                    lblModelMsg.Text = ex.Message;
                    upModel.Update();
                    return -1;
                }
            }
            return -1;

        }
    }
}