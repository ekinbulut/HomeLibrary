using System;
using System.Linq;
using Library.Business.Services.Book.Dtos;
using Library.Data.Athentication.Repositories.Users;
using Library.Data.Entities;
using Library.Data.Enums;
using Library.Data.Repositories.Books;

namespace Library.Business.Services.Book
{
    public class BookServiceApplication : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public BookServiceApplication(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets the book list.
        /// </summary>
        /// <returns></returns>
        public BookOutputDto GetBookList()
        {
            BookOutputDto bookoutput = new BookOutputDto();

            var books = _bookRepository.GetAll().ToList();

            if (books.Any())
            {
                foreach (var eBook in books)
                {
                    var book = new BookDto();
                    book.Id = eBook.Id;
                    book.Name = eBook.Name;
                    book.Author = eBook.Author.Name;
                    book.Publisher = eBook.Publisher.Name;
                    book.Genre = eBook.Genre.Genre;
                    book.No = eBook.No;
                    book.Rack = eBook.Rack.RackNumber;
                    book.Shelf = eBook.Shelf.Name;
                    book.SkinType = Enum.GetName(typeof(SkinType), eBook.SkinType);
                    book.Serie = eBook.Serie != null ? eBook.Serie.Name : string.Empty;
                    book.PublishDate = eBook.PublishDate;

                    bookoutput.Books.Add(book);
                }

            }
            return bookoutput;
        }

        public BookOutputDto GetBookListByUserId(int userId)
        {
            BookOutputDto bookoutput = new BookOutputDto();

            var books = _bookRepository.GetBooksWithUserId(userId).ToList();

            if (books.Any())
            {
                foreach (var eBook in books)
                {
                    var book = new BookDto();
                    book.Id = eBook.Id;
                    book.Name = eBook.Name;
                    book.Author = eBook.Author.Name;
                    book.Publisher = eBook.Publisher.Name;
                    book.Genre = eBook.Genre.Genre;
                    book.No = eBook.No;
                    book.Rack = eBook.Rack.RackNumber;
                    book.Shelf = eBook.Shelf.Name;
                    book.SkinType = Enum.GetName(typeof(SkinType), eBook.SkinType);
                    book.Serie = eBook.Serie != null ? eBook.Serie.Name : string.Empty;
                    book.PublishDate = eBook.PublishDate;

                    bookoutput.Books.Add(book);
                }

            }
            return bookoutput;
        }

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>boolean</returns>
        public bool AddBook(BookInputDto input)
        {
            var user = _userRepository.GetOne(input.UserId);

            var book = new EBook()
            {
                SkinType = input.SkinType == 0 ? SkinType.Ciltli : SkinType.Ciltsiz,
                Name = input.Name,
                SeriesId = input.Serie == 0 ? (int?) null : input.Serie,
                AuthorId = input.Author,
                CreatedDateTime = DateTime.Now,
                PublishDate = input.PublishDate,
                PublisherId = input.Publisher,
                GenreId = input.Genre,
                ShelfId = input.Shelf,
                RackId = input.Rack,
                No = input.No,
            };

            book.Users.Add(user);

            var newRecord = _bookRepository.CreateEntity(book);


            return newRecord != null;
            
        }

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>boolean</returns>
        public bool UpdateBook(BookDto input)
        {
            return _bookRepository.UpdateEntity(input.Id, new EBook()
            {
                Name = input.Name
                
            });
        }
    }
}
