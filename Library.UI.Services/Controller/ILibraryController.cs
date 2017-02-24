using System.Collections.Generic;
using Library.Business.Services.Book.Dtos;
using Library.Business.Services.Provider.Dtos;
using Library.UI.Services.Model;

namespace Library.UI.Services.Controller
{
    public interface ILibraryController
    {
        ICollection<BookDto> GetBooks(UserModelView user);
        IEnumerable<BookView> ConvertBooks(ICollection<BookDto> books);
        ICollection<SeriesDto> BindSeries();
        bool AddBook(BookView bookInput);
        ICollection<AuthorDto> BindAuthors();
        ICollection<GenreDto> BindGenres();
        ICollection<PublisherDto> BindPublishers();
        ICollection<ShelfDto> BindShelfs();
        ICollection<RackDto> BindRacks();

        ICollection<SkinType> BindSkins();
    }
}