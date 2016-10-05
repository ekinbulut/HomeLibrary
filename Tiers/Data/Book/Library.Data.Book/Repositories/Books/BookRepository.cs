using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Book.Repositories.Books
{
    public class BookRepository : EfRepositoryBase<EBook,int>, IBookRepository
    {


        public bool FindBook(string name)
        {
            return DbContext.Set<EBook>().Any(x => x.Name.Equals(name));
        }

        public BookRepository(DbContext dbContext) : base(dbContext)
        {
        }

    }
}
