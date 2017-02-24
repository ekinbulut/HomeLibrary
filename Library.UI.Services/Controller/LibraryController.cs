using System;
using System.Collections.Generic;
using System.Linq;
using Library.Business.Services.Book.Dtos;
using Library.Business.Services.Provider.Dtos;
using Library.UI.Services.Model;
using IServiceProvider = Library.UI.Services.Providers.IServiceProvider;

namespace Library.UI.Services.Controller
{
    public class LibraryController :  BaseController, ILibraryController
    {
        public ICollection<BookDto> GetBooks(UserModelView user)
        {
            var bookoutputdto = ServiceProvider.BookService.GetBookListByUserId(user.UserId);

            return bookoutputdto.Books;
        }

        public IEnumerable<BookView> ConvertBooks(ICollection<BookDto> books)
        {
            return (from b in books
                    select new BookView()
                    {
                        Id = b.Id,
                        Author = b.Author,
                        No = String.IsNullOrEmpty(b.No) ? (int?)null : int.Parse(b.No),
                        PublishDate = b.PublishDate,
                        Genre = b.Genre,
                        Name = b.Name,
                        Serie = b.Serie,
                        Publisher = b.Publisher,
                        SkinType = b.SkinType,
                        Shelf = b.Shelf,
                        Rack = b.Rack
                    });
        }

        public ICollection<SeriesDto> BindSeries()
        {
            var seriesOutputDto = ServiceProvider.ItemsProvider.Series();
            return seriesOutputDto.SeriesDtos;
        }

        public bool AddBook(BookView book)
        {
            var bookInput = new BookInputDto()
            {
                
            };
            return ServiceProvider.BookService.AddBook(bookInput);
        }

        public ICollection<AuthorDto> BindAuthors()
        {
            return ServiceProvider.ItemsProvider.Authors().AuthorDtos;
        }

        public ICollection<GenreDto> BindGenres()
        {
            return ServiceProvider.ItemsProvider.Genres().GenreDtos;
        }

        public ICollection<PublisherDto> BindPublishers()
        {
            return ServiceProvider.ItemsProvider.Publishers().PublisherDtos;
        }

        public ICollection<ShelfDto> BindShelfs()
        {
            return ServiceProvider.ItemsProvider.Shelfs().ShelfDtos;
        }

        public ICollection<RackDto> BindRacks()
        {
            return ServiceProvider.ItemsProvider.Racks().RackDtos;
        }

        public ICollection<SkinType> BindSkins()
        {
            return new List<SkinType>()
            {
                new SkinType()
                {
                    Name = "Ciltli",
                    Value = "0"
                },
                new SkinType()
                {
                    Name = "Ciltsiz",
                    Value = "1"
                }
            };
        }

        public LibraryController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
