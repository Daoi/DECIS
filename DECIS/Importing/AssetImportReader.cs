using DECIS.DataAccess.DataAccessors.Assets.Types;
using DECIS.DataAccess.DataAccessors.Location;
using DECIS.DataAccess.DataAccessors.Make;
using DECIS.DataAccess.DataAccessors.Model;
using DECIS.DataAccess.DataAccessors.Status;
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
    public class AssetImportReader
    {
        private DataSet sheets;
        DataTable intakeInfo;
        DataTable assetInfo;
        DataTable modelDT = new GetAllModel().ExecuteCommand();
        DataTable makeDT = new GetAllMake().ExecuteCommand();
        DataTable statusDT = new GetAllStatus().ExecuteCommand();
        DataTable locationDT = new GetAllLocation().ExecuteCommand();
        DataTable typeDT = new GetAllAssetTypes().ExecuteCommand();


        public AssetImportReader(string filePath) {

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    sheets = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            FilterRow = (rowReader) => {
                                int progress = (int)Math.Ceiling((decimal)rowReader.Depth / (decimal)rowReader.RowCount * (decimal)100);
                                // progress is in the range 0..100
                                return true;
                            }
                        }
                    });

                    // The result of each spreadsheet is in sheets.Tables
                }
            }
            //Next steps here
            intakeInfo = sheets.Tables["Donor Info"];
            assetInfo = sheets.Tables["Asset Info"];

            Intake curIntake = CreateIntakeForm();
            if (curIntake != null)
            {

            }
            else
                throw new FormatException("Invalid donor info sheet");
            

        }


        private Intake CreateIntakeForm()
        {
            try
            { 
                foreach(DataRow dr in intakeInfo.Rows)
                {
                    return new Intake(dr);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        private List<Asset> CreateAssets()
        {
            List<Asset> assets = new List<Asset>();
            foreach(DataRow dr in assetInfo.Rows)
            {
                try
                {
                    Asset curAsset = new Asset()
                    {
                        AssetTypeID = FindID(typeDT, dr, "AssetType", "AssetTypeID"),
                        AssetType = dr["Equipment Type"].ToString(),
                        Make = dr["Make"].ToString(),
                        MakeID = FindID(makeDT, dr, "Make", "MakeID"),
                        Model = dr["Model"].ToString(),
                        ModelID = FindID(modelDT, dr, "Model", "ModelID"),
                        SerialNumber = dr["Serial Number"].ToString(),
                        Description = dr["Asset Description"].ToString()
                    };
                    assets.Add(curAsset);
                }
                catch(Exception e)
                {
                    continue;
                }
            }
            return assets;
        }

        /// <summary>
        /// Find the ID for a value in the spreadsheet.
        /// </summary>
        /// <param name="dt">Datatable(Look up table) from the database</param>
        /// <param name="dr">Datarow from the spreadsheet</param>
        /// <param name="drColumn">The column from the current row of the spreadsheet</param>
        /// <param name="dtColumn">The column in the datatable to look for the ID in</param>
        /// <returns>the ID of the value from the database</returns>
        private int FindID(DataTable dt, DataRow dr, string drColumn, string dtColumn)
        {
            int id = makeDT.AsEnumerable().SingleOrDefault
                     (r => r.Field<string>(drColumn) == dr[drColumn].ToString())
                     .Field<int>(dtColumn);

            return id;
        }
    }
}