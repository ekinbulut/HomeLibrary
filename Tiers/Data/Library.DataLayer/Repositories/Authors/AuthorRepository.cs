using System;
using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Authors
{
    public class AuthorRepository : EfRepositoryBase<EAuthor,int> , IAuthorRepository
    {

        public EAuthor GetAuthorByName(string name)
        {
            return DbContext.Set<EAuthor>().FirstOrDefault(x => x.Name == name);
        }

        public EAuthor CreateIfAuthorIsNotExists(string name)
        {
            var author = DbContext.Set<EAuthor>().FirstOrDefault(x => x.Name == name) ??
                         this.CreateEntity(new EAuthor() {Name = name, CreatedDateTime = DateTime.Now});

            return author;
        }

        public AuthorRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
