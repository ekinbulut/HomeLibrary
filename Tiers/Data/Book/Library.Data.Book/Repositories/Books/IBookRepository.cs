using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Book.Repositories.Books
{
    public interface IBookRepository : IRepository<EBook,int>
    {
        bool FindBook(string name);
    }
}