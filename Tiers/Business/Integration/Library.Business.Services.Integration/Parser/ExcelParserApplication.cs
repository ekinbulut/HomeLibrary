using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;

namespace Library.Business.Services.Integration.Parser
{
    public class ExcelParserApplication : IParserApplication
    {
        /// <summary>
        /// Reads the excel file.
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ReadExcelFile()
        {
            var filePath = ConfigurationManager.AppSettings["FilePath"];

            var excelfiles = Directory.GetFiles(filePath, "*.xlsx").ToList();


            foreach (var excelfile in excelfiles)
            {
                var connectionStr =
                    String.Format(@"Provider={0};Data Source={1};Extended Properties=""{2};HDR={3}""", "Microsoft.ACE.OLEDB.12.0", excelfile, "Excel 12.0 Xml", "YES");

                OleDbAConnector.ConnectionStr = connectionStr;
                OleDbAConnector.SheetName = "Kitaplık";

                var datatable = OleDbAConnector.ExecuteOleDbConnection();

                return datatable;

            }

            return null;
        }

        /// <summary>
        /// Reads the excel file. Calls by IntegrationServices
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>DataTable</returns>
        public DataTable ReadExcelFile(string filepath)
        {

            //var connectionStr = String.Format(@"Provider={0};Data Source={1};Extended Properties=""{2};HDR={3}""", "Microsoft.ACE.OLEDB.12.0", filepath, "Excel 12.0 Xml", "YES");
            
            var connectionStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filepath};Extended Properties=Excel 12.0 Xml;HDR=YES";

            OleDbAConnector.ConnectionStr = connectionStr;
            OleDbAConnector.SheetName = "Kitaplık";

            var datatable = OleDbAConnector.ExecuteOleDbConnection();

            return datatable;

        }

        public DataTable ReadCSVFile(string filepath)
        {
            DataTable table = new DataTable();

            //Name	Author	Publisher	Series	Genre	PublishDate	No	Cilt	RackNumber	Shelf


            using (StreamReader reader = new StreamReader(filepath))
            {
                string Fulltext;
                while (!reader.EndOfStream)
                {
                    Fulltext = reader.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Length - 1; i++)  
                    {  
                        string[] rowValues = rows[i].Split(';'); //split each row with comma to get individual values  
                        {  
                            if (i == 0)  
                            {  
                                for (int j = 0; j < rowValues.Length; j++)  
                                {  
                                    table.Columns.Add(rowValues[j]); //add headers  
                                }  
                            }  
                            else  
                            {  
                                DataRow dr = table.NewRow();  
                                for (int k = 0; k < rowValues.Length; k++)  
                                {  
                                    dr[k] = rowValues[k].ToString();  
                                }  
                                table.Rows.Add(dr); //add other rows  
                            }  
                        }  
                    } 

                }

            }

            return table;


            return null;
        }
    }

    public interface IParserApplication
    {
        DataTable ReadExcelFile(string filepath);

        DataTable ReadExcelFile();

        DataTable ReadCSVFile(string filepath);
    }
}
