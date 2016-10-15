using System.Data;

namespace Library.Business.Services.Integration.Model
{
    internal class Importer : IImporter
    {
        public ImportObject ConvertRowIntoImportObject(DataRow row)
        {
            return new ImportObject()
            {
                BookName = row.ItemArray[0].ToString(),
                AuthorName = row.ItemArray[1].ToString(),
                PublisherName = row.ItemArray[2].ToString(),
                Publishdate = row.ItemArray[3].ToString(),
                GenreName = row.ItemArray[4].ToString(),
                SerieName = row.ItemArray[5].ToString(),
                No = row.ItemArray[6].ToString(),
                Skintype = row.ItemArray[7].ToString(),
                RackId = row.ItemArray[9].ToString(),
                ShelfId = row.ItemArray[10].ToString()
            };
        }
    }
}