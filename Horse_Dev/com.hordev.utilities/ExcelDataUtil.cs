
using ExcelDataReader;
using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Horse_Dev.com.hordev.utilities
{
    public class ExcelDataUtil
    {
        private static void QuitExcel(string processtitle)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;
            foreach (var process in processes)
                if (process.MainWindowTitle == "Microsoft Excel - " + processtitle + " - Excel")
                    process.Kill();
        }
        private static void ClearData()
        {
            DataCol.Clear();
        }
        public  DataTable ReadExcelData(String fileName,string sheetName)
        {

            System.IO.FileStream file = File.Open(fileName, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(file);
            var conf = new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            };


            DataSet result = excelReader.AsDataSet(conf);
            DataTableCollection table = result.Tables;
            DataTable resultTable = table[sheetName];

            Console.WriteLine(resultTable);
            return resultTable;
        }

        static List<CollectionData> DataCol = new List<CollectionData>();

        public void GetDataInCollection(String fileName,String sheetName)
        {
            DataTable dataTable = ReadExcelData(fileName, sheetName);
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                for (int column = 0; column < dataTable.Columns.Count; column++)
                {
                    CollectionData collectionDT = new CollectionData()
                    {
                        rowNum = row,
                        colunmName = dataTable.Columns[column].ColumnName,
                        colunmValue = dataTable.Rows[row][column].ToString()
                    };
                    DataCol.Add(collectionDT);
                }
            }
        }

            public string ReadData(int rowNumber, string ColName)
             {
                try
                {
                rowNumber = rowNumber - 1;
                string data = (from colData in DataCol
                                   where colData.colunmName == ColName && colData.rowNum == rowNumber
                                   select colData.colunmValue).SingleOrDefault();
                    return data.ToString();
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null; 
                }
               
            }
    


        public class CollectionData
    {
        public int rowNum { get; set; }
        public string colunmName { get; set; }
        public string colunmValue { get; set; }
    }
}
}
