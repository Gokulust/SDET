using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopCommerce_Selenium.Helpers
{
    internal class ExcelUtils
    {
        public static List<T> ReadSearchData<T>(string excelFilePath, string sheetName, Func<DataRow, T> excelObjFunction) where T : new()
        {
            List<T> excelSearchList = new List<T>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {

                        foreach (DataRow row in dataTable.Rows)
                        {
                            var data = excelObjFunction(row);
                            excelSearchList.Add(data);
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }

                }
            }
            return excelSearchList;

        }
        public static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }




    }
}
