using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Books
{
    public class BookRepository : EfRepositoryBase<EBook,int>, IBookRepository
    {
        public BookRepository(DbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public bool FindBook(string name)
        {
            return DbContext.Set<EBook>().Any(x => x.Name.Equals(name));
        }
    }
}
