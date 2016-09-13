using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Authors
{
    public class AuthorRepository : EfRepositoryBase<EAuthor,int> , IAuthorRepository
    {
        public AuthorRepository(DbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public EAuthor GetAuthorByName(string name)
        {
            return DbContext.Set<EAuthor>().FirstOrDefault(x => x.Name == name);
        }
    }
}
