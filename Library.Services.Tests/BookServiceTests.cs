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
                Name = "",
                Author = new EAuthor { Name = "" },
                Publisher = new EPublisher { Name = "" },
                Serie = new ESeries { Name = "" },
                PublishDate = It.IsAny<int>(),
                Genre = new EGenre {  Genre = "" },
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


            var list = _bookServiceApplication.GetBookList();

            Assert.Equal(1, list.Books.Count);
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

    }
}
