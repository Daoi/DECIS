using DECIS.CotrolLogic;
using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS
{
    public partial class Settings : System.Web.UI.Page
    {
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
            string imagePath = Server.MapPath($"./Importing/Images/") + fuModelImage.FileName + RandomizeString.RandomString(5); //Try to prevent duplicate names
            fuModelImage.SaveAs(imagePath);

            Model mdl = new Model()
            {
                ModelName = tbModelName.Text,
                AssetType = ddlAssetType.SelectedItem.Text,
                AssetTypeID = int.Parse(ddlAssetType.SelectedValue),
                Make = ddlAssetMake.SelectedItem.Text,
                MakeID = int.Parse(ddlAssetMake.SelectedValue),
                Image = imagePath
            };


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