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
        [MemberData(nameof(BookInput))]
        public void WhenAddBook_ReturnsSuccess(BookInputDto input)
        {
            //TODO: setup userrepository Getone
            //TODO: setup bookrepository createEntity
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


        public static IEnumerable<object[]> BookInput()
        {

            yield return new object[] {

                new BookInputDto{ },
                new BookInputDto{ }

            };
        }
    }
}
