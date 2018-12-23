using Library.Data.Entities;

namespace Library.Business.Services.Integration.Model
{
    public class ImportObject
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string Publishdate { get; set; }
        public string GenreName { get; set; }
        public string SerieName { get; set; }
        public string No { get; set; }
        public string Skintype { get; set; }
        public string RackId { get; set; }
        public string ShelfId { get; set; }
        public EUser User { get; set; }

    }
}
