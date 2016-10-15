using System.Data;

namespace Library.Business.Services.Integration.Model
{
    public interface IImporter
    {
        ImportObject ConvertRowIntoImportObject(DataRow row);
    }
}