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
        public List<Asset> Duplicates { get; set; }
        public int Rows { get; set; }


        public AssetImportReader(string filePath, string selectedOrg) {

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
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
                    //If no assets were added delete last intake
                    string delete = $"DELETE FROM intake WHERE IntakeID = {intakeID}";
                    new CTextWriter(delete).ExecuteCommand();
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
                        IntakeID = new List<int>()
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
                    DataRow result = new ImportAsset().ExecuteCommand(asset, intakeID).Rows[0];
                    if (result != null) //Serial Number Already Exists
                    {
                        int x;
                        if (int.TryParse(result["AssetID"].ToString(), out x))
                            asset.AssetID = x;
                        else
                            asset.AssetID = -1;

                        Duplicates.Add(asset);
                        //If further error handling is needed later can seperate between duplicates/other errors 
                        //if (int.TryParse(result["Status"].ToString(), out x))
                        //    if(x != ) If an item is duplicate serial number and not donated/recycled status something is wrong
                        //        Errors.Add(asset);
                        //else
                        //    Duplicates.Add(asset);
                    }
                }
                catch(Exception e)
                {
                    assets.Remove(asset);
                }
            }

            foreach(Asset duplicate in Duplicates)
            {
                assets.Remove(duplicate);
            }

            return assets;
        }

        public void HandleDuplicates(List<Asset> retries)
        {
            foreach(Asset ast in retries)
            {
                if(Duplicates.Exists(a => a.SerialNumber == ast.SerialNumber))
                {
                    //Update status
                    new UpdateAssetStatusOnImport().ExecuteCommand(ast.AssetID, intakeID);
                }
                else//Eventually handle other errors
                {
                    var result = new ImportAsset().ExecuteCommand(ast, intakeID);
                }
            }
        }

    }
}