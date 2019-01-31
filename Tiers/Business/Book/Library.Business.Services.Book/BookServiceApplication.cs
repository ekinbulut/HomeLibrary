using System;
using System.Linq;
using Castle.Core.Internal;
using Library.Business.Services.Book.Dtos;
using Library.Business.Services.Helper;
using Library.Data.Entities;
using Library.Data.Books.Repositories;
using Library.Data.Users.Repositories;
using Library.Data.Entities.Enums;

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
                    BookDto book = new BookDto
                    {
                        Id = eBook.Id,
                        Name = eBook.Name,
                        Author = eBook.Author.Name,
                        Publisher = eBook.Publisher.Name,
                        Genre = eBook.Genre.Genre,
                        No = eBook.No.ToString(),
                        Rack = eBook.Rack.RackNumber,
                        Shelf = eBook.Shelf.Name,
                        SkinType = Enum.GetName(typeof(SkinType), eBook.SkinType),
                        Serie = eBook.Serie != null ? eBook.Serie.Name : string.Empty,
                        PublishDate = eBook.PublishDate,
                        CreatedDateTime = eBook.CreatedDateTime
                    };


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
                    BookDto book = new BookDto
                    {
                        Id = eBook.Id,
                        Name = eBook.Name,
                        Author = eBook.Author.Name,
                        Publisher = eBook.Publisher.Name,
                        Genre = eBook.Genre.Genre,
                        No = eBook.No.ToString(),
                        Rack = eBook.Rack.RackNumber,
                        Shelf = eBook.Shelf.Name,
                        SkinType = Enum.GetName(typeof(SkinType), eBook.SkinType),
                        Serie = eBook.Serie != null ? eBook.Serie.Name : string.Empty,
                        PublishDate = eBook.PublishDate,
                        CreatedDateTime = eBook.CreatedDateTime
                    };

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

            var book = new EBook
            {
                SkinType = input.SkinType == 0 ? SkinType.Ciltli : SkinType.Ciltsiz,
                Name = input.Name.Trim(),
                SeriesId = input.Serie == 0 ? (int?)null : input.Serie,
                AuthorId = input.Author,
                CreatedDateTime = DateTime.Now,
                PublishDate = input.PublishDate,
                PublisherId = input.Publisher,
                GenreId = input.Genre,
                ShelfId = input.Shelf,
                RackId = input.Rack
                //No = int.TryParse(input.No, out number) ? number : (int?) null
            };


            if (!String.IsNullOrEmpty(input.No))
            {

                book.No = int.TryParse(input.No, out int no) ? no : input.No.RomanToInteger();
            }
            else
            {
                book.No = null;
            }



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
            var entity = _bookRepository.GetOne(input.Id);

            entity.Name = input.Name;

            if (!input.Author.IsNullOrEmpty())
            {
                entity.AuthorId = int.Parse(input.Author);
            }
            if (!input.Publisher.IsNullOrEmpty())
            {
                entity.PublisherId = Int32.Parse(input.Publisher);
            }

            entity.SeriesId = Int32.TryParse(input.Serie, out int outValue) ? outValue : (int?)null;


            entity.PublishDate = input.PublishDate;

            if (!input.Genre.IsNullOrEmpty())
            {
                entity.GenreId = Int32.Parse(input.Genre);

            }
            if (!input.SkinType.IsNullOrEmpty())
            {
                entity.SkinType = int.Parse(input.SkinType) == 0 ? SkinType.Ciltli : SkinType.Ciltsiz;

            }
            if (!input.Shelf.IsNullOrEmpty())
            {
                entity.ShelfId = Int32.Parse(input.Shelf);

            }
            if (input.Rack != 0)
            {
                entity.RackId = input.Rack;

            }

            if (!String.IsNullOrEmpty(input.No))
            {

                entity.No = int.TryParse(input.No, out int no) ? no : input.No.RomanToInteger();
            }
            else
            {
                entity.No = null;
            }

            return _bookRepository.UpdateEntity(entity);
        }

        /// <summary>
        /// Calls repository for deletetion
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool DeleteBook(BookDto input)
        {
            return _bookRepository.DeleteEntity(input.Id);
        }

        /// <summary>
        /// Returns books in a range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public BookOutputDto GetBooksRangeBy(int start, int length, int userId)
        {
            BookOutputDto bookoutput = new BookOutputDto();

            // get book count for related user
            int count = _bookRepository.GetBooksWithUserId(userId).ToList().Count();

            bookoutput.TotalBook = count;


            var books = _bookRepository.GetBooksRangeBy(start, length, userId).ToList();

            if (books.Any())
            {
                foreach (var eBook in books)
                {
                    BookDto book = new BookDto
                    {
                        Id = eBook.Id,
                        Name = eBook.Name,
                        Author = eBook.Author.Name,
                        Publisher = eBook.Publisher.Name,
                        Genre = eBook.Genre.Genre,
                        No = eBook.No.ToString(),
                        Rack = eBook.Rack.RackNumber,
                        Shelf = eBook.Shelf.Name,
                        SkinType = Enum.GetName(typeof(SkinType), eBook.SkinType),
                        Serie = eBook.Serie != null ? eBook.Serie.Name : string.Empty,
                        PublishDate = eBook.PublishDate,
                        CreatedDateTime = eBook.CreatedDateTime
                    };

                    bookoutput.Books.Add(book);
                }

            }
            return bookoutput;

        }

        public BookOutputDto GetBooksSearchRangeBy(int start, int length, string searchKey, int userId)
        {
            BookOutputDto bookoutput = new BookOutputDto();

            // get book count for related user
            int count = _bookRepository.GetBooksSearchRangeBy(searchKey, userId).ToList().Count();

            bookoutput.TotalBook = count;


            var books = _bookRepository.GetBooksSearchRangeBy(searchKey, userId).OrderBy(x=>x.Name).Skip(start).Take(length).ToList();

            if (books.Any())
            {
                foreach (var eBook in books)
                {
                    BookDto book = new BookDto
                    {
                        Id = eBook.Id,
                        Name = eBook.Name,
                        Author = eBook.Author.Name,
                        Publisher = eBook.Publisher.Name,
                        Genre = eBook.Genre.Genre,
                        No = eBook.No.ToString(),
                        Rack = eBook.Rack.RackNumber,
                        Shelf = eBook.Shelf.Name,
                        SkinType = Enum.GetName(typeof(SkinType), eBook.SkinType),
                        Serie = eBook.Serie != null ? eBook.Serie.Name : string.Empty,
                        PublishDate = eBook.PublishDate,
                        CreatedDateTime = eBook.CreatedDateTime
                    };

                    bookoutput.Books.Add(book);
                }

            }
            return bookoutput;
        }
    }
}
