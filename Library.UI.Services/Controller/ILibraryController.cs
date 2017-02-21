﻿using System.Collections.Generic;
using Library.Business.Services.Book.Dtos;
using Library.UI.Services.Model;

namespace Library.UI.Services.Controller
{
    public interface ILibraryController
    {
        ICollection<BookDto> GetBooks(UserModel user);
    }
}