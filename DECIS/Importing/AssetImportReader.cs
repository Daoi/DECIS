using DECIS.DataAccess.DataAccessors;
using DECIS.DataAccess.DataAccessors.Assets;
using DECIS.DataAccess.DataAccessors.Assets.Types;
using DECIS.DataAccess.DataAccessors.Intake;
using DECIS.DataAccess.DataAccessors.Location;
using DECIS.DataAccess.DataAccessors.Make;
using DECIS.DataAccess.DataAccessors.Model;
using DECIS.DataAccess.DataAccessors.Status;
using DECIS.DataAccess.Utilities;
using DECIS.DataModels;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DECIS.Importing
{
    [Serializable]
    public class AssetImportReader
    {
        private DataSet sheets;
        public List<Asset> assets { get; set; }
        DataTable intakeInfo;
        DataTable assetInfo;
        DataTable modelDT = new GetAllModel().ExecuteCommand();
        DataTable makeDT = new GetAllMake().ExecuteCommand();
        DataTable statusDT = new GetAllStatus().ExecuteCommand();
        DataTable locationDT = new GetAllLocation().ExecuteCommand();
        DataTable typeDT = new GetAllAssetTypes().ExecuteCommand();
        int intakeID;
        int tempID = 0;
        public List<Asset> Duplicates { get; set; }
        public int Rows { get; set; }
        public int Successful { get; set; }


        public AssetImportReader(FileUpload fu, string selectedOrg) {
            Successful = 0;
            using (var stream = fu.PostedFile.InputStream)
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    sheets = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                }
            }
            //Next steps here
            intakeInfo = sheets.Tables["Donor Info"];
            assetInfo = sheets.Tables["Asset Info"].Rows
                .Cast<DataRow>()
                .Where(row => !row.ItemArray.All(val => val is DBNull || string.IsNullOrWhiteSpace(val as string))) //Remove empty rows
                .CopyToDataTable();

            Rows = assetInfo.Rows.Count;

            if (selectedOrg != "New Organization")
                intakeInfo.Rows[0]["Donor's Organization"] = selectedOrg;

            try
            {
                Intake curIntake = CreateIntakeForm();
                intakeID = curIntake.IntakeID;
                assets = CreateAssets();
                if (assets.Count == 0 && Duplicates.Count == 0)
                {
                    Abort();
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        private Intake CreateIntakeForm()
        {
            try
            {
                DataRow dr = intakeInfo.Rows[0];
                return Intake.ImportIntake(dr);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private List<Asset> CreateAssets()
        {
            List<Asset> assets = new List<Asset>();
            Duplicates = new List<Asset>();

            foreach(DataRow dr in assetInfo.Rows)
            {
                try
                {
                    Asset curAsset = new Asset()
                    {
                        AssetTypeID = FindIDWithWhere.FindID(typeDT, dr, "AssetType", "Equipment Type", "AssetTypeID"),
                        AssetType = dr["Equipment Type"].ToString(),
                        SerialNumber = dr["Serial Number"].ToString(),
                        Description = $"Make: {dr["Make"].ToString()} Model: {dr["Model"].ToString()}, Description: {dr["Asset Description"].ToString()}",
                        IntakeID = new List<int>(),
                        AssetID = tempID++
                    };
                    curAsset.IntakeID.Add(intakeID);
                    assets.Add(curAsset);
                }
                catch(Exception e)
                {
                    continue;
                }
            }

            foreach(Asset asset in assets)
            {
                try
                {
                    DataRow result = new ImportAsset().ExecuteCommand(asset, intakeID).Rows[0] ?? null;
                    if (result != null)
                    {
                        int x;
                        if(int.TryParse(result["AssetID"].ToString(), out x)) { 

                            if(result.Table.Columns.Contains("SerialNumber")) //Duplicate asset found
                            {
                                Successful--;
                                asset.AssetID = x;
                                asset.Location = result["Location"].ToString();
                                asset.Status = result["Status"].ToString();
                                Duplicates.Add(asset);

                            }
                            else
                            {
                                asset.AssetID = x; //New assets only return their ID
                                Successful++;
                            }
                        }
                    }
                }
                catch(Exception e)
                {
                    assets.Remove(asset);
                }
            }
            foreach(Asset asset in Duplicates)
            {
                assets.Remove(asset);
            }

            return assets;
        }

        public void HandleDuplicates(List<Asset> retries)
        {
            if (Successful < 0)
                Successful = 0;

            foreach(Asset ast in retries)
            {
                try
                {
                    if (Duplicates.Exists(a => a.SerialNumber == ast.SerialNumber))//Check resubmitted serial numbers against original found sn
                    {
                        //Update status of existing object
                        new UpdateAssetStatusOnImport().ExecuteCommand(ast.AssetID, intakeID);
                        Successful++;
                        Duplicates.Remove(Duplicates.Find(a => a.SerialNumber == ast.SerialNumber));
                    }
                    else//If it's an error and the serial number was corrected
                    {
                        var result = new ImportAsset().ExecuteCommand(ast, intakeID);
                        Successful++;
                        Duplicates.Remove(Duplicates.Find(a => a.AssetID == ast.AssetID));
                    }
                }
                catch(Exception e)
                {
                    Successful--;
                }
            }

            if (Successful <= 0)
                Abort();
        }
        /// <summary>
        /// Delete intake in db
        /// </summary>
        public void Abort()
        {
            string delete = $"DELETE FROM intake WHERE IntakeID = {intakeID}";
            new CTextWriter(delete).ExecuteCommand();
        }

    }
}