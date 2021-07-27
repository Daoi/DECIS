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

                    // The result of each spreadsheet is in result.Tables
                }
            }

        }

    }
}