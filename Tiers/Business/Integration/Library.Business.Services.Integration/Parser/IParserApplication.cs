using System.Data;

namespace Library.Business.Services.Integration.Parser
{
    public interface IParserApplication
    {
        DataTable ReadExcelFile(string filepath);

        DataTable ReadCSVFile(string filepath);
    }
}
