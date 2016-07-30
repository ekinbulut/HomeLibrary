using Castle.Core.Internal;
using Library.Business.Dtos;
using Library.Business.Services;
using Library.DataLayer.Repositories.Authors;
using Library.DataLayer.Repositories.Genres;
using Library.DataLayer.Repositories.Publishers;
using Library.DataLayer.Repositories.Racks;
using Library.DataLayer.Repositories.Series;
using Library.DataLayer.Repositories.Shelfs;

namespace Library.Business.Applications
{
    public class ItemProviderServiceApplication : IItemProvider
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IShelfRepository _shelfRepository;
        private readonly IRackRepository _rackRepository;

        public ItemProviderServiceApplication(IAuthorRepository authorRepository, IPublisherRepository publisherRepository, IGenreRepository genreRepository, ISeriesRepository seriesRepository, IShelfRepository shelfRepository, IRackRepository rackRepository)
        {
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _genreRepository = genreRepository;
            _seriesRepository = seriesRepository;
            _shelfRepository = shelfRepository;
            _rackRepository = rackRepository;
        }


        public AuthorOutputDto Authors()
        {
            var output = new AuthorOutputDto();

            _authorRepository.GetAll().ForEach(a =>
            {
                output.AuthorDtos.Add(new AuthorDto()
                {
                    Name = a.Name,
                    Value = a.Id
                });
            });

            return output;
        }

        public PublisherOutputDto Publishers()
        {
            var output = new PublisherOutputDto();

            _publisherRepository.GetAll().ForEach(p =>
            {
                output.PublisherDtos.Add(new PublisherDto()
                {
                    Value = p.Id,
                    Name = p.Name
                });
            });

            return output;
        }

        public GenreOutputDto Genres()
        {
            var output = new GenreOutputDto();

            _genreRepository.GetAll().ForEach(g =>
            {
                output.GenreDtos.Add(new GenreDto()
                {
                    Name = g.Genre,
                    Value = g.Id
                });
            });

            return output;
        }

        public SeriesOutputDto Series()
        {
            var output = new SeriesOutputDto();

            _seriesRepository.GetAll().ForEach(s =>
            {
                output.SeriesDtos.Add(new SeriesDto()
                {
                    Name = s.Name,
                    Value = s.Id
                });
            });


            return output;
        }

        public ShelfOutputDto Shelfs()
        {
            var output = new ShelfOutputDto();

            _shelfRepository.GetAll().ForEach(s =>
            {
                output.ShelfDtos.Add(new ShelfDto()
                {
                    Name = s.Name,
                    Value = s.Id
                });
            });

            return output;
        }

        public RackOutputDto Racks()
        {
            var output = new RackOutputDto();

            _rackRepository.GetAll().ForEach(r =>
            {
                output.RackDtos.Add(new RackDto()
                {
                    Name = r.RackNumber.ToString(),
                    Value = r.Id
                });
            });

            return output;
        }
    }
}
