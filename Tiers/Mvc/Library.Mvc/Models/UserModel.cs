﻿using System;
using Library.Business.Services.Book.Dtos;

namespace Library.Mvc.Models
{
    public class UserModel
    {
        public Guid Identity { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string Role { get; set; }
        public int UserId { get; set; }
        public bool RememberMe { get; set; }

        public BookOutputDto BookOutputDto { get; set; }
        public BookModel BookModel { get; set; }
        public AuthorModel AuthorModel { get; set; }
        public PublisherModel PublisherModel { get; set; }
        public BookDto BookDto { get; set; }
    }
}
