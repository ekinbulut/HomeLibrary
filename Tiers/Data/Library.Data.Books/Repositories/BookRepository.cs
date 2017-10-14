using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Context;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Books.Repositories
{
    public class BookRepository : EfRepositoryBase<EBook,int>, IBookRepository
    {
        public BookRepository(BaseContext dbContext) : base(dbContext)
        {
        }

        public bool FindBook(string name)
        {
            return DbContext.Set<EBook>().Any(x => x.Name.Equals(name));
        }

        public IQueryable<EBook> GetBooksWithUserId(int userId)
        {
            return DbContext.Set<EBook>().Where(x => x.Users.Any(u => u.Id == userId));
        }

        public EBook GetBookByName(string bookName)
        {
            return DbContext.Set<EBook>().FirstOrDefault(x => x.Name.Equals(bookName));
        }

        public bool CheckIfBookExistsByNameWriterAndByPublisher(string bookName, string authorName, string publisherName)
        {
            return DbContext.Set<EBook>().Any(x => x.Name.Equals(bookName) && x.Publisher.Name.Equals(publisherName) && x.Author.Name.Equals(authorName));

        }

        public EBook GetBookByNameAndByPublisher(string bookName, string authorName, string publisherName)
        {
            return DbContext.Set<EBook>().FirstOrDefault(x => x.Name.Equals(bookName) && x.Publisher.Name.Equals(publisherName) && x.Author.Name.Equals(authorName));

        }

        public IQueryable<EBook> GetBooksRangeBy(int start, int length, int userId)
        {
            return DbContext.Set<EBook>().OrderBy(x=>x.Id).Skip(start).Take(length).Where(x => x.Users.Any(u => u.Id == userId));
        }

        public IQueryable<EBook> GetBooksSearchRangeBy(string searchKey, int userId)
        {
            return DbContext.Set<EBook>()
                .OrderBy(x => x.Id)
                .Where(x => x.Users.Any(u => u.Id == userId) 
                && x.Author.Name.Contains(searchKey)
                || x.Name.Contains(searchKey));

        }


    }
}
