using System.Data;

namespace Library.Business.Services.Integration.Parser
{
    public interface IParserApplication
    {
        DataTable ReadExcelFile(string filepath);

        DataTable ReadExcelFile();

        DataTable ReadCSVFile(string filepath);
    }
}
