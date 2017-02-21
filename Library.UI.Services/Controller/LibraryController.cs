using System.Collections.Generic;
using Library.Business.Services.Book.Dtos;
using Library.UI.Services.Model;
using Library.UI.Services.Providers;

namespace Library.UI.Services.Controller
{
    public class LibraryController :  BaseController, ILibraryController
    {
        public ICollection<BookDto> GetBooks(UserModel user)
        {
            var bookoutputdto = ServiceProvider.BookService.GetBookListByUserId(user.UserId);

            return bookoutputdto.Books;
        }

        public LibraryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
