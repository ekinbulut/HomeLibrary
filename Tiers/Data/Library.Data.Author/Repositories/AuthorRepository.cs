using System;
using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Context;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Author.Repositories.Authors
{
    public class AuthorRepository : EfRepositoryBase<EAuthor,int,AuthorContext> , IAuthorRepository
    {

        public AuthorRepository(AuthorContext dbContext) : base(dbContext)
        {
        }

        public EAuthor GetAuthorByName(string name)
        {
            return DbContext.Set<EAuthor>().FirstOrDefault(x => x.Name == name);
        }

        public EAuthor CreateIfAuthorIsNotExists(string name)
        {
            var author = DbContext.Set<EAuthor>().FirstOrDefault(x => x.Name == name) ??
                         CreateEntity(new EAuthor {Name = name, CreatedDateTime = DateTime.Now});

            return author;
        }



    }
}
