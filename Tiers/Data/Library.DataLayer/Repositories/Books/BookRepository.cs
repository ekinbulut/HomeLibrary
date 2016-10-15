using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Books
{
    public class BookRepository : EfRepositoryBase<EBook,int>, IBookRepository
    {


        public bool FindBook(string name)
        {
            return DbContext.Set<EBook>().Any(x => x.Name.Equals(name));
        }

        public IQueryable<EBook> GetBooksWithUserId(int userId)
        {
            return DbContext.Set<EBook>().Where(x => x.UserId == userId);
        }

        public BookRepository(DbContext dbContext) : base(dbContext)
        {
        }

    }
}
