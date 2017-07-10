using Library.Business.Services.Book.Dtos;

namespace Library.Web.Models
{
    public class BookReturnModel
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }

        public BookDto[] Data { get; set; }

    }
}