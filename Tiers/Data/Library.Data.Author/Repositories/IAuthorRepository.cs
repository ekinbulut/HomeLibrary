﻿using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Author.Repositories.Authors
{
    public interface IAuthorRepository : IRepository<EAuthor,int>
    {
        EAuthor GetAuthorByName(string name);
        EAuthor CreateIfAuthorIsNotExists(string name);
    }
}