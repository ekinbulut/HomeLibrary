using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Books
{
    public interface IBookRepository : IRepository<EBook,int>
    {
        bool FindBook(string name);
        IQueryable<EBook> GetBooksWithUserId(int userId);
        EBook GetBookByName(string bookName);
        bool CheckIfBookExistsByNameWriterAndByPublisher(string bookName,string authorName, string publisherName);
        EBook GetBookByNameAndByPublisher(string bookName, string authorName, string publisherName);
    }
}