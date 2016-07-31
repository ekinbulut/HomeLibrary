using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;

namespace Library.Business.Parser
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

            var connectionStr =
                String.Format(@"Provider={0};Data Source={1};Extended Properties=""{2};HDR={3}""", "Microsoft.ACE.OLEDB.12.0", filepath, "Excel 12.0 Xml", "YES");

            OleDbAConnector.ConnectionStr = connectionStr;
            OleDbAConnector.SheetName = "Kitaplık";

            var datatable = OleDbAConnector.ExecuteOleDbConnection();

            return datatable;

        }
    }

    public interface IParserApplication
    {
        DataTable ReadExcelFile(string filepath);
    }
}
