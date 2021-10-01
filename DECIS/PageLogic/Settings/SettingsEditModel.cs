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
    public class SettingsEditModel
    {
        private static string bucketImages = "decisimages";

        public static int Edit(Page pg)
        {
            //Find Controls
            TextBox tbModelName = FindControl.Find("tbModelName", pg) as TextBox;
            Label lblModelMsg = FindControl.Find("lblModelMsg", pg) as Label;
            DropDownList ddlAssetType = FindControl.Find("ddlAssetType", pg) as DropDownList;
            DropDownList ddlAssetMake = FindControl.Find("ddlAssetMake", pg) as DropDownList;
            FileUpload fuModelImage = FindControl.Find("fuModelImage", pg) as FileUpload;
            UpdatePanel upModel = FindControl.Find("upModel", pg) as UpdatePanel;
            int modelID;
            Model mdl = null;
            string url = "";
            bool awsResult = false;
            string[] parts = tbModelName.Text.Split(','); //Format should be "Model Name,ModelID"
            
            if (!int.TryParse(parts[1], out modelID))
            {
                lblModelMsg.Text = "Updating models the format 'Model Name,ModelID' e.g. Optiplex 990,5 ";
            }
            else
            {
                try
                {
                    mdl = new Model(new GetModelByID().ExecuteCommand(modelID).Rows[0]);
                }
                catch(Exception ex)
                {
                    lblModelMsg.Text = "Invalid ID provided";
                    return -1;
                }
            }

            if (fuModelImage.HasFile)
            {
                Stream s = fuModelImage.PostedFile.InputStream;
                string[] image = fuModelImage.FileName.Split('.');
                string imageName = $"{parts[0]}{DateTime.Today.ToShortDateString().Replace("/","")}.{image[1]}";//Try to prevent duplicate names
                AmazonUploader myUploader = new AmazonUploader();
                string key;
                try
                {
                    key = mdl.Image.Split(new string[] { "/Images/" }, StringSplitOptions.None)[1]; // https://decisimages.s3.us-east-2.amazonaws.com/Images/ is the base url, what follows is the Key
                    awsResult = myUploader.UploadFileToS3Public(s, bucketImages, imageName, out url, "Images", key);
                }
                catch (IndexOutOfRangeException)
                {
                    awsResult = myUploader.UploadFileToS3Public(s, bucketImages, imageName, out url, "Images");
                }
            }
            else
                awsResult = true; //Nothing with image is changing so the operation succeeded



            if (awsResult)
            {
                mdl.ModelID = modelID;
                mdl.ModelName = parts[0];
                mdl.AssetType = ddlAssetType.SelectedItem.Text;
                mdl.AssetTypeID = int.Parse(ddlAssetType.SelectedValue);
                mdl.Make = ddlAssetMake.SelectedItem.Text;
                mdl.MakeID = int.Parse(ddlAssetMake.SelectedValue);
                mdl.Image = string.IsNullOrWhiteSpace(url) ? mdl.Image : url;

                try
                {
                    int x = new UpdateModel().ExecuteCommand(mdl);
                    lblModelMsg.Text = $"Succesfully updated {mdl.ModelName}";
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