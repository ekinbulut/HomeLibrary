using System;
using System.Collections.Generic;
using Library.Business.Services.Provider;
using Library.Business.Services.Provider.Dtos;
using Library.Data.Author.Repositories.Authors;
using Library.Data.Entities;
using Library.Data.Genres.Repositories;
using Library.Data.Publishers.Repositories;
using Library.Data.Racks.Repositories;
using Library.Data.Series.Repositories;
using Library.Data.Shelfs.Repositories;
using Moq;
using Xunit;

namespace Library.Services.Tests
{
    public class ProviderServiceTests
    {
        readonly ItemProviderServiceApplication _sut;

        public ProviderServiceTests()
        {
            var authorRepository = new Mock<IAuthorRepository>();
            var publisherRepository = new Mock<IPublisherRepository>();
            var genreRepository = new Mock<IGenreRepository>();
            var seriesRepository = new Mock<ISeriesRepository>();
            var shelfRepository = new Mock<IShelfRepository>();
            var rackRepository = new Mock<IRackRepository>();

            authorRepository.Setup(s => s.GetAll())
                .Returns(() => new List<EAuthor>()
                {
                    new EAuthor
                    {
                        Books = null,
                        Id = 1,
                        Name = "author_name"
                    }
                });

            publisherRepository.Setup(s => s.GetAll())
                .Returns(() => new List<EPublisher>()
                {
                    new EPublisher
                    {
                        Books = null,
                        CreatedDateTime = Convert.ToDateTime("01.01.2019 00:00:00"),
                        Id = 1,
                        Name = "publisher_name",
                        Series = new List<ESeries>()
                        {
                            new ESeries
                            {
                                Name = "series_name",
                                CreatedDateTime = Convert.ToDateTime("01.01.2019 00:00:00"),
                                Id = 1,
                            }
                        }
                    }
                });

            genreRepository.Setup(s => s.GetAll()).
                Returns(() => new List<EGenre>()
                {
                    new EGenre
                    {
                        Id = 1,
                        Genre = "genre",
                        CreatedDateTime = Convert.ToDateTime("01.01.2019 00:00:00")
                    }
                });

            seriesRepository.Setup(s => s.GetAll())
                .Returns(() => new List<ESeries>()
                {
                    new ESeries
                    {
                        Name = "series_name",
                        CreatedDateTime = Convert.ToDateTime("01.01.2019 00:00:00"),
                        Id = 1
                    }
                });

            shelfRepository.Setup(s => s.GetAll())
                .Returns(() => new List<EShelf>()
                {
                    new EShelf
                    {
                        Id = 1,
                        Name = "shelf_name",
                        CreatedDateTime = Convert.ToDateTime("01.01.2019 00:00:00")
                    }
                });

            rackRepository.Setup(s => s.GetAll())
                .Returns(()=> new List<ERack>()
                {
                    new ERack
                    {
                        Id = 1,
                        RackNumber = 1,
                        CreatedDateTime = Convert.ToDateTime("01.01.2019 00:00:00")
                    },
                    new ERack
                    {
                        Id = 2,
                        RackNumber = 2,
                        CreatedDateTime = Convert.ToDateTime("01.01.2019 00:00:00")
                    }
                });

            _sut = new ItemProviderServiceApplication(authorRepository.Object, publisherRepository.Object,
                genreRepository.Object, seriesRepository.Object, shelfRepository.Object, rackRepository.Object);


        }

        [Fact]
        public void If_AuthorRepository_Returns_All_Returns_AuthorOutputDto()
        {
            var actual = _sut.Authors();

            Assert.IsType<AuthorOutputDto>(actual);
        }

        [Fact]
        public void If_PublisherRepository_Returns_All_Returns_PublisherOutputDto()
        {
            var actual = _sut.Publishers();

            Assert.IsType<PublisherOutputDto>(actual);
        }

        [Fact]
        public void If_GenreRepository_Returns_All_Returns_GenreOutputDto()
        {
            var actual = _sut.Genres();

            Assert.IsType<GenreOutputDto>(actual);
        }

        [Fact]
        public void If_SeriesRepository_Returns_All_Returns_SeriesOutputDto()
        {
            var actual = _sut.Series();

            Assert.IsType<SeriesOutputDto>(actual);
        }

        [Fact]
        public void If_ShelfRepository_Returns_All_Returns_ShelfOutputDto()
        {
            var actual = _sut.Shelfs();

            Assert.IsType<ShelfOutputDto>(actual);
        }

        [Fact]
        public void If_RackRepository_Returns_All_Returns_RackOutputDto()
        {
            var actual = _sut.Racks();

            Assert.IsType<RackOutputDto>(actual);
        }
    }
}
