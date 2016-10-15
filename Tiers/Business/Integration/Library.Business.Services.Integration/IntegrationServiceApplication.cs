using System;
using System.Configuration;
using System.Data;
using System.IO;
using Castle.Core.Internal;
using Castle.Core.Logging;
using Library.Business.Services.Integration.Dtos;
using Library.Business.Services.Integration.Parser;
using Library.Data.Athentication.Repositories.Users;
using Library.Data.Entities;
using Library.Data.Enums;
using Library.Data.Repositories.Authors;
using Library.Data.Repositories.Books;
using Library.Data.Repositories.Genres;
using Library.Data.Repositories.Publishers;
using Library.Data.Repositories.Racks;
using Library.Data.Repositories.Series;
using Library.Data.Repositories.Shelfs;

namespace Library.Business.Services.Integration
{
    public class IntegrationServiceApplication : IIntegrationService
    {
        private readonly IParserApplication _parserApplication;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IShelfRepository _shelfRepository;
        private readonly IRackRepository _rackRepository;
        private readonly ILogger _logger;

        public IntegrationServiceApplication(IParserApplication parserApplication, IBookRepository bookRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository, IGenreRepository genreRepository, ISeriesRepository seriesRepository, IShelfRepository shelfRepository, IRackRepository rackRepository, ILogger logger)
        {
            _parserApplication = parserApplication;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _genreRepository = genreRepository;
            _seriesRepository = seriesRepository;
            _shelfRepository = shelfRepository;
            _rackRepository = rackRepository;
            _logger = logger;

        }

        /// <summary>
        /// Imports the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public bool Import(string input,int userId)
        {

            try
            {
                var datatable = _parserApplication.ReadExcelFile(input);

                foreach (DataRow row in datatable.Rows)
                {
                    var bookName = row.ItemArray[0].ToString();
                    var authorName = row.ItemArray[1].ToString();
                    var publisherName = row.ItemArray[2].ToString();
                    var publishdate = row.ItemArray[3].ToString();
                    var genreName = row.ItemArray[4].ToString();
                    var serieName = row.ItemArray[5].ToString();
                    var no = row.ItemArray[6].ToString();
                    var skintype = row.ItemArray[7].ToString();
                    var rackId = row.ItemArray[9].ToString();
                    var shelfId = row.ItemArray[10].ToString();

                    if (!_bookRepository.FindBook(bookName)) //if not exist
                    {
                        var author = _authorRepository.GetAuthorByName(authorName) ?? _authorRepository.CreateEntity(new EAuthor() { Name = authorName, CreatedDateTime = DateTime.Now });
                        var publisher = _publisherRepository.GetPublisherByName(publisherName) ?? _publisherRepository.CreateEntity(new EPublisher() { Name = publisherName, CreatedDateTime = DateTime.Now });
                        var genre = _genreRepository.GetGenreByName(genreName) ?? _genreRepository.CreateEntity(new EGenre() { Genre = genreName, CreatedDateTime = DateTime.Now });

                        ESeries serie;
                        if (!serieName.IsNullOrEmpty())
                        {
                            serie = _seriesRepository.GetSeriesbyName(serieName) ?? _seriesRepository.CreateEntity(new ESeries() { Name = serieName, Publisher = publisher, CreatedDateTime = DateTime.Now });
                        }
                        else
                        {
                            serie = null;
                        }
                        var skin = skintype.ToLowerInvariant().Equals("ciltli") ? SkinType.Ciltli : SkinType.Ciltsiz;
                        var rack = _rackRepository.GetRackByRackNumber(int.Parse(rackId));
                        var shelf = _shelfRepository.GetShelfById(int.Parse(shelfId));

                        var entity = new EBook();
                        entity.Name = bookName;
                        entity.Author = author;
                        entity.Publisher = publisher;
                        entity.PublishDate = int.Parse(publishdate);
                        entity.Genre = genre;
                        entity.Serie = serie;
                        entity.No = String.IsNullOrEmpty(no) ? null : no;
                        entity.SkinType = skin;
                        entity.Rack = rack;
                        entity.Shelf = shelf;
                        entity.CreatedDateTime = DateTime.Now;
                        entity.UserId = userId;

                        _bookRepository.CreateEntity(entity);
                    }

                }

                return true;
            }
            catch (Exception error)
            {
                _logger.Error("Integration Error", error);

                return false;
            }
        }

        /// <summary>
        /// Creates the author.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public bool CreateAuthor(AuthorInputDto input)
        {
            if (String.IsNullOrEmpty(input.AuthorDto.Name))
            {
                return false;
            }

            var result = _authorRepository.CreateEntity(new EAuthor()
            {
                Name = input.AuthorDto.Name,
                CreatedDateTime = DateTime.Now
            });

            return result != null;
        }

        /// <summary>
        /// Creates the publisher.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public bool CreatePublisher(PublisherInputDto input)
        {
            if (String.IsNullOrEmpty(input.PublisherName))
            {
                return false;
            }

            var publisher = _publisherRepository.GetPublisherByName(input.PublisherName);

            if (publisher == null)
            {
                var new_publisher = _publisherRepository.CreateEntity(new EPublisher()
                {
                    Name = input.PublisherName,
                    CreatedDateTime = DateTime.Now
                });

                if (!String.IsNullOrEmpty(input.SeriesName))
                {
                    _seriesRepository.CreateEntity(new ESeries()
                    {
                        Name = input.SeriesName,
                        Publisher = publisher,
                        CreatedDateTime = DateTime.Now

                    });
                }

                return new_publisher != null;

            }

            return publisher != null;
        }


        public bool SendFile(IntegrationInputDto input)
        {
            var docname = input.IntegrationDto.DocName;
            var path = ConfigurationManager.AppSettings["UploadFile"];
            var strdocPath = Path.Combine(path, docname);
            

            using (FileStream objfilestream = new FileStream(strdocPath, FileMode.Create, FileAccess.ReadWrite))
            {
                var byteArray = input.IntegrationDto.ByteArray;
                objfilestream.Write(byteArray, 0, byteArray.Length);
                objfilestream.Close();
            }

            return Import(strdocPath, input.IntegrationDto.UserId);
        }
    }
}
