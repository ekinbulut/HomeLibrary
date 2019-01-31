using Castle.Core.Internal;
using Library.Business.Services.Provider.Dtos;
using Library.Data.Author.Repositories.Authors;
using Library.Data.Genres.Repositories;
using Library.Data.Publishers.Repositories;
using Library.Data.Racks.Repositories;
using Library.Data.Series.Repositories;
using Library.Data.Shelfs.Repositories;

namespace Library.Business.Services.Provider
{
    public class ItemProviderServiceApplication : IItemProvider
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IShelfRepository _shelfRepository;
        private readonly IRackRepository _rackRepository;

        public ItemProviderServiceApplication(IAuthorRepository authorRepository
            , IPublisherRepository publisherRepository
            , IGenreRepository genreRepository
            , ISeriesRepository seriesRepository
            , IShelfRepository shelfRepository
            , IRackRepository rackRepository)
        {
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _genreRepository = genreRepository;
            _seriesRepository = seriesRepository;
            _shelfRepository = shelfRepository;
            _rackRepository = rackRepository;
        }

        /// <summary>
        /// Return Authors list.
        /// </summary>
        /// <returns></returns>
        public AuthorOutputDto Authors()
        {
            var output = new AuthorOutputDto();

            foreach (var a in _authorRepository.GetAll())
            {
                output.AuthorDtos.Add(new AuthorDto
                {
                    Name = a.Name,
                    Value = a.Id
                });
            }

            return output;
        }

        /// <summary>
        /// Returns Publishers list.
        /// </summary>
        /// <returns></returns>
        public PublisherOutputDto Publishers()
        {
            var output = new PublisherOutputDto();

            foreach (var p in _publisherRepository.GetAll())
            {
                 output.PublisherDtos.Add(new PublisherDto
                {
                    Value = p.Id,
                    Name = p.Name
                });
            }

            return output;
        }

        /// <summary>
        /// Returns Genre list.
        /// </summary>
        /// <returns></returns>
        public GenreOutputDto Genres()
        {
            var output = new GenreOutputDto();

            foreach (var g in _genreRepository.GetAll())
            {
                output.GenreDtos.Add(new GenreDto
                {
                    Name = g.Genre,
                    Value = g.Id
                });
            }

            return output;
        }

        /// <summary>
        /// Return Series list.
        /// </summary>
        /// <returns></returns>
        public SeriesOutputDto Series()
        {
            var output = new SeriesOutputDto();

            foreach (var s in _seriesRepository.GetAll())
            {
                output.SeriesDtos.Add(new SeriesDto
                {
                    Name = s.Name,
                    Value = s.Id
                });
            }

            return output;
        }

        /// <summary>
        /// Returns Shelf list.
        /// </summary>
        /// <returns></returns>
        public ShelfOutputDto Shelfs()
        {
            var output = new ShelfOutputDto();

            foreach (var s in _shelfRepository.GetAll())
            {
                 output.ShelfDtos.Add(new ShelfDto
                {
                    Name = s.Name,
                    Value = s.Id
                });
            }

            return output;
        }
        
        /// <summary>
        /// Returns Racks list.
        /// </summary>
        /// <returns></returns>
        public RackOutputDto Racks()
        {
            var output = new RackOutputDto();

            foreach (var r in _rackRepository.GetAll())
            {
                output.RackDtos.Add(new RackDto
                {
                    Name = r.RackNumber.ToString(),
                    Value = r.Id
                });
            }


            return output;
        }
    }
}
