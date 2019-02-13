using Library.Business.Services.Book;
using Library.Business.Services.Book.Dtos;
using Library.Data.Books.Repositories;
using Library.Data.Entities;
using Library.Data.Users.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Library.Services.Tests
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _bookRepository;
        private readonly Mock<IUserRepository> _userRepository;
        private BookServiceApplication _bookServiceApplication;

        public BookServiceTests()
        {
            _bookRepository = new Mock<IBookRepository>();
            _userRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public void WhenGetBookListMethodCall_ReturnsSuccess()
        {


            EBook demo = new EBook()
            {
                Id = 1,
                Name = "demo",
                Author = new EAuthor { Name = "" },
                Publisher = new EPublisher { Name = "" },
                Serie = new ESeries { Name = "" },
                PublishDate = It.IsAny<int>(),
                Genre = new EGenre { Genre = "" },
                No = 1,
                SkinType = Data.Entities.Enums.SkinType.Ciltli,
                Shelf = new EShelf { Name = "" },
                Rack = new ERack { RackNumber = 1 },
                CreatedDateTime = DateTime.Now,
                SeriesId = 0
            };

            _bookRepository.Setup(r => r.GetAll()).Returns(
               new List<EBook>()
               {
                    demo
               });



            _bookServiceApplication = new BookServiceApplication(_bookRepository.Object, _userRepository.Object);


            BookOutputDto output = _bookServiceApplication.GetBookList();

            Assert.Collection<BookDto>(output.Books, t => Assert.Contains("demo", t.Name));

        }

        [Fact]
        public void WhenGetBookListByUserId_ReturnsSuccess()
        {

            EBook demo = new EBook()
            {
                Id = 1,
                Name = "demo",
                Author = new EAuthor { Name = "" },
                Publisher = new EPublisher { Name = "" },
                Serie = new ESeries { Name = "" },
                PublishDate = It.IsAny<int>(),
                Genre = new EGenre { Genre = "" },
                No = 1,
                SkinType = Data.Entities.Enums.SkinType.Ciltli,
                Shelf = new EShelf { Name = "" },
                Rack = new ERack { RackNumber = 1 },
                CreatedDateTime = DateTime.Now,
                SeriesId = 0
            };

            _bookRepository.Setup(m => m.GetBooksWithUserId(It.IsAny<int>()))
                .Returns(new List<EBook>()
                {
                    demo
                }.AsQueryable());

            _bookServiceApplication = new BookServiceApplication(_bookRepository.Object, _userRepository.Object);

            BookOutputDto output = _bookServiceApplication.GetBookListByUserId(It.IsAny<int>());

            Assert.Collection<BookDto>(output.Books, t => Assert.Contains("demo", t.Name));

        }

        [Theory]
        [MemberData(nameof(BookInputDto))]
        public void WhenAddBook_ReturnsSuccess(BookInputDto input)
        {
            _userRepository.Setup(m => m.GetOne(It.IsAny<int>())).Returns(new EUser());
            _bookRepository.Setup(m => m.CreateEntity(It.IsAny<EBook>())).Returns(new EBook());

            _bookServiceApplication = new BookServiceApplication(_bookRepository.Object, _userRepository.Object);
            bool result = _bookServiceApplication.AddBook(input);

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(BookDto))]
        public void WhenUpdateBook_ReturnSuccess(BookDto input)
        {
            EBook book = new EBook
            {
                Name = "DEMO",
                AuthorId = 1,
                PublisherId = 1,
                SeriesId = 1,
                PublishDate = 1,
                GenreId = 1,
                ShelfId = 1,
                RackId = 1,
            };


            _bookRepository.Setup(m => m.GetOne(input.Id)).Returns(book);

            _bookRepository.Setup(m => m.UpdateEntity(book)).Returns(true);


            _bookServiceApplication = new BookServiceApplication(_bookRepository.Object, _userRepository.Object);

            bool result = _bookServiceApplication.UpdateBook(input);

            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(BookDto))]
        public void WhenDeleteBook_ReturnSucess(BookDto input)
        {

            _bookRepository.Setup(m => m.DeleteEntity(input.Id)).Returns(true);

            _bookServiceApplication = new BookServiceApplication(_bookRepository.Object, _userRepository.Object);
            bool result = _bookServiceApplication.DeleteBook(input);

            Assert.True(result);

        }

        [Fact]
        public void WhenGetBooksRangeBy_ReturnsSuccess()
        {

            EBook book = new EBook
            {
                Id = 1,
                Name = "demo",
                Author = new EAuthor { Name = "" },
                Publisher = new EPublisher { Name = "" },
                Serie = new ESeries { Name = "" },
                PublishDate = It.IsAny<int>(),
                Genre = new EGenre { Genre = "" },
                No = 1,
                SkinType = Data.Entities.Enums.SkinType.Ciltli,
                Shelf = new EShelf { Name = "" },
                Rack = new ERack { RackNumber = 1 },
                CreatedDateTime = DateTime.Now,
                SeriesId = 0

            };

            _bookRepository.Setup(r => r.GetBooksWithUserId(It.IsAny<int>())).Returns(new List<EBook>() { book }.AsQueryable());
            _bookRepository.Setup(r => r.GetBooksRangeBy(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<EBook>() { book }.AsQueryable());

            _bookServiceApplication = new BookServiceApplication(_bookRepository.Object, _userRepository.Object);

            var result = _bookServiceApplication.GetBooksRangeBy(0, 10, 1);

            Assert.Equal(1, result.TotalBook);
        }


        [Fact]
        public void WhenGetBooksSearchRangeBy_ReturnsSuccess()
        {

            IQueryable<EBook> list = Ebooks.AsQueryable();

            _bookRepository.Setup(r => r.GetBooksSearchRangeBy("de", It.IsAny<int>())).Returns(list);

            _bookServiceApplication = new BookServiceApplication(_bookRepository.Object, _userRepository.Object);

            var result = _bookServiceApplication.GetBooksSearchRangeBy(0, 10, "de", 1);

            Assert.Equal(list.Count(), result.TotalBook);
        }

        [Fact]
        public void WhenGetBookListMethodCall_ThrowNullReferenceException()
        {
            _bookRepository.Setup(r => r.GetAll()).Returns(
                new List<EBook>()
                {
                    new EBook() { Id = 1, Author = It.IsAny<EAuthor>() }
                });

            _bookServiceApplication = new BookServiceApplication(_bookRepository.Object, _userRepository.Object);


            Assert.Throws<NullReferenceException>(() => { _bookServiceApplication.GetBookList(); });
        }


        public static IEnumerable<object[]> BookInputDto = new List<object[]>
        {
            new object[]{ new BookInputDto { SkinType = 1, Name = "DEMO", Serie = 0, Author = 1, PublishDate = 1, Publisher = 1, Genre = 1, Shelf = 1, Rack = 1 } },
            new object[]{ new BookInputDto { SkinType = 1, Name = "DEMO", Serie = 0, Author = 1, PublishDate = 1, Publisher = 1, Genre = 1, Shelf = 1, Rack = 1, No = "1" } }
        };

        public static IEnumerable<object[]> BookDto = new List<object[]>
        {
            new object[]{ new BookDto { Id = 1, Name ="DEMO", Author = "1", Publisher = "1", Serie = "1", PublishDate = 1, Genre = "1", SkinType = "1", Shelf = "1", Rack=1, No = "1"  } },
            new object[]{ new BookDto { Id = 1, Name ="DEMO", Author = "1", Publisher = "1", Serie = "", PublishDate = 1, Genre = "1", SkinType = "1", Shelf = "1", Rack=1, No = ""  } },
        };

        public static IEnumerable<EBook> Ebooks= new List<EBook>
        {
             new EBook
            {
                Id = 1,
                Name = "demo",
                Author = new EAuthor { Name = "" },
                Publisher = new EPublisher { Name = "" },
                Serie = new ESeries { Name = "" },
                PublishDate = It.IsAny<int>(),
                Genre = new EGenre { Genre = "" },
                No = 1,
                SkinType = Data.Entities.Enums.SkinType.Ciltli,
                Shelf = new EShelf { Name = "" },
                Rack = new ERack { RackNumber = 1 },
                CreatedDateTime = DateTime.Now,
                SeriesId = 0

            },
            new EBook
            {
                Id = 2,
                Name = "ekin",
                Author = new EAuthor { Name = "" },
                Publisher = new EPublisher { Name = "" },
                Serie = new ESeries { Name = "" },
                PublishDate = It.IsAny<int>(),
                Genre = new EGenre { Genre = "" },
                No = 1,
                SkinType = Data.Entities.Enums.SkinType.Ciltli,
                Shelf = new EShelf { Name = "" },
                Rack = new ERack { RackNumber = 1 },
                CreatedDateTime = DateTime.Now,
                SeriesId = 0

            }
        };


    }
}
