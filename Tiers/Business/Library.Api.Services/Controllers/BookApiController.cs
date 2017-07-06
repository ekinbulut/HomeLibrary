using System;
using System.Linq;
using System.Web.Http;
using Library.Api.Objects;
using Library.Api.Services.Helpers;
using Library.Data.Entities;
using Library.Data.Enums;
using Library.Data.Repositories.Books;
using Library.Data.Repositories.Users;

namespace Library.Api.Services.Controllers
{
    [RoutePrefix("api/book")]
    [Authorize]
    public class BookApiController : BaseApiController , IBookApiController
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public BookApiController(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets the book list.
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
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
                    book.No = eBook.No.ToString();
                    book.Rack = eBook.Rack.RackNumber;
                    book.Shelf = eBook.Shelf.Name;
                    book.SkinType = Enum.GetName(typeof(SkinType), eBook.SkinType);
                    book.Serie = eBook.Serie != null ? eBook.Serie.Name : string.Empty;
                    book.PublishDate = eBook.PublishDate;
                    book.CreatedDateTime = eBook.CreatedDateTime;

                    bookoutput.Books.Add(book);
                }

            }
            return bookoutput;

        }

        /// <summary>
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
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
                    book.No = eBook.No.ToString();
                    book.Rack = eBook.Rack.RackNumber;
                    book.Shelf = eBook.Shelf.Name;
                    book.SkinType = Enum.GetName(typeof(SkinType), eBook.SkinType);
                    book.Serie = eBook.Serie != null ? eBook.Serie.Name : string.Empty;
                    book.PublishDate = eBook.PublishDate;
                    book.CreatedDateTime = eBook.CreatedDateTime;

                    bookoutput.Books.Add(book);
                }

            }
            return bookoutput;
        }

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool AddBook([FromBody]BookInputDto input)
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
                int no = 0;

                book.No = int.TryParse(input.No, out no) ? no : input.No.RomanToInteger();
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
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public bool UpdateBook([FromBody]BookDto input)
        {
            var entity = _bookRepository.GetOne(input.Id);

            //todo: change entity

            entity.Name = input.Name;

            if (!String.IsNullOrEmpty(input.Author))
            {
                entity.AuthorId = int.Parse(input.Author);
            }
            if (!String.IsNullOrEmpty(input.Publisher))
            {
                entity.PublisherId = Int32.Parse(input.Publisher);
            }

            int outValue = 0;
            entity.SeriesId = Int32.TryParse(input.Serie, out outValue) ? outValue : (int?)null;


            entity.PublishDate = input.PublishDate;

            if (!String.IsNullOrEmpty(input.Genre))
            {
                entity.GenreId = Int32.Parse(input.Genre);

            }
            if (!String.IsNullOrEmpty(input.SkinType))
            {
                entity.SkinType = int.Parse(input.SkinType) == 0 ? SkinType.Ciltli : SkinType.Ciltsiz;

            }
            if (!String.IsNullOrEmpty(input.Shelf))
            {
                entity.ShelfId = Int32.Parse(input.Shelf);

            }
            if (input.Rack != 0)
            {
                entity.RackId = input.Rack;

            }

            if (!String.IsNullOrEmpty(input.No))
            {
                int no = 0;

                entity.No = int.TryParse(input.No, out no) ? no : input.No.RomanToInteger();
            }
            else
            {
                entity.No = null;
            }

            return _bookRepository.UpdateEntity(entity);
        }

        /// <summary>
        /// Deletes book record with Id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize]
        public bool DeleteBook([FromBody]BookDto input)
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
        [Authorize]
        public BookOutputDto GetBooksRangeBy(int start, int length, int userId)
        {
            BookOutputDto bookoutput = new BookOutputDto();

            // get book count for related user
            var count = _bookRepository.GetBooksWithUserId(userId).ToList().Count();

            bookoutput.TotalBook = count;


            var books = _bookRepository.GetBooksRangeBy(start, length, userId).ToList();

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
                    book.No = eBook.No.ToString();
                    book.Rack = eBook.Rack.RackNumber;
                    book.Shelf = eBook.Shelf.Name;
                    book.SkinType = Enum.GetName(typeof(SkinType), eBook.SkinType);
                    book.Serie = eBook.Serie != null ? eBook.Serie.Name : string.Empty;
                    book.PublishDate = eBook.PublishDate;
                    book.CreatedDateTime = eBook.CreatedDateTime;

                    bookoutput.Books.Add(book);
                }

            }
            return bookoutput;

        }


        /// <summary>
        /// Returns record in search
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="searchKey"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Authorize]
        public BookOutputDto GetBooksSearchRangeBy(int start, int length, string searchKey, int userId)
        {
            BookOutputDto bookoutput = new BookOutputDto();

            // get book count for related user
            var count = _bookRepository.GetBooksSearchRangeBy(searchKey, userId).ToList().Count();

            bookoutput.TotalBook = count;


            var books = _bookRepository.GetBooksSearchRangeBy(searchKey, userId).OrderBy(x => x.Name).Skip(start).Take(length).ToList();

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
                    book.No = eBook.No.ToString();
                    book.Rack = eBook.Rack.RackNumber;
                    book.Shelf = eBook.Shelf.Name;
                    book.SkinType = Enum.GetName(typeof(SkinType), eBook.SkinType);
                    book.Serie = eBook.Serie != null ? eBook.Serie.Name : string.Empty;
                    book.PublishDate = eBook.PublishDate;
                    book.CreatedDateTime = eBook.CreatedDateTime;

                    bookoutput.Books.Add(book);
                }

            }
            return bookoutput;

        }
    }
}