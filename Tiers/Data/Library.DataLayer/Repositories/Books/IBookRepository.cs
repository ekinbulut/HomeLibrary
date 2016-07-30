using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Books
{
    public interface IBookRepository : IRepository<EBook,int>
    {
        bool FindBook(string name);
    }
}