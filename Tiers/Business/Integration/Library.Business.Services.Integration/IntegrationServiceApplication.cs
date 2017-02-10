using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using Castle.Core.Internal;
using Castle.Core.Logging;
using Library.Business.Services.Helper;
using Library.Business.Services.Integration.Dtos;
using Library.Business.Services.Integration.Model;
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
    public class IntegrationServiceApplication : IIntegrationService , IValidation
    {
        private readonly IParserApplication _parserApplication;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IShelfRepository _shelfRepository;
        private readonly IRackRepository _rackRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly IImporter _importer;

        public IntegrationServiceApplication(IParserApplication parserApplication, IBookRepository bookRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository, IGenreRepository genreRepository, ISeriesRepository seriesRepository, IShelfRepository shelfRepository, IRackRepository rackRepository, ILogger logger, IUserRepository userRepository, IImporter importer)
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
            _userRepository = userRepository;
            _importer = importer;
        }

        /// <summary>
        /// Imports the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public bool Import(string input, int userId)
        {

            try
            {
                var datatable = _parserApplication.ReadExcelFile(input);

                var user = _userRepository.GetOne(userId);

                foreach (DataRow row in datatable.Rows)
                {
                    var importerObject = _importer.ConvertRowIntoImportObject(row);

                    if (IsEmpty(importerObject))
                    {
                        continue;
                    }

                    var exists = _bookRepository.CheckIfBookExistsByNameWriterAndByPublisher(importerObject.BookName.Trim(), importerObject.AuthorName.Trim(), importerObject.PublisherName.Trim());

                    if (!exists)
                    {
                        var author = _authorRepository.CreateIfAuthorIsNotExists(importerObject.AuthorName.Trim());
                        var publisher = _publisherRepository.CreatePublisherIfNotExists(importerObject.PublisherName.Trim());
                        var genre = _genreRepository.CreateGenreIfNotExists(importerObject.GenreName.Trim());

                        ESeries serie;
                        if (!importerObject.SerieName.IsNullOrEmpty())
                        {
                            serie = _seriesRepository.GetSeriesbyName(importerObject.SerieName.Trim()) ?? _seriesRepository.CreateEntity(new ESeries() { Name = importerObject.SerieName.Trim(), Publisher = publisher, CreatedDateTime = DateTime.Now });
                        }
                        else
                        {
                            serie = null;
                        }
                        var skin = importerObject.Skintype.ToLowerInvariant().Equals("ciltli") ? SkinType.Ciltli : SkinType.Ciltsiz;
                        var rack = _rackRepository.GetRackByRackNumber(int.Parse(importerObject.RackId));
                        var shelf = _shelfRepository.GetShelfById(int.Parse(importerObject.ShelfId));

                        var entity = new EBook();
                        entity.Name = importerObject.BookName.Trim();
                        entity.Author = author;
                        entity.Publisher = publisher;
                        entity.PublishDate = int.Parse(importerObject.Publishdate);
                        entity.Genre = genre;
                        entity.Serie = serie;


                        int no = 0;
                        entity.No = !String.IsNullOrEmpty(importerObject.No)
                            ? (entity.No =
                                int.TryParse(importerObject.No, out no) ? no : importerObject.No.RomanToInteger())
                            : entity.No = null;

                        entity.SkinType = skin;
                        entity.Rack = rack;
                        entity.Shelf = shelf;
                        entity.CreatedDateTime = DateTime.Now;

                        entity.Users.Add(user);

                        _bookRepository.CreateEntity(entity);
                    }
                    else
                    {
                        var book = _bookRepository.GetBookByNameAndByPublisher(importerObject.BookName.Trim(), importerObject.AuthorName.Trim(), importerObject.PublisherName.Trim());

                        if (!book.Users.Contains(user))
                        {
                            book.Users.Add(user);
                            _bookRepository.UpdateEntity(book);

                        }
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
                Name = input.AuthorDto.Name.Trim(),
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

            var publisher = _publisherRepository.GetPublisherByName(input.PublisherName.Trim());

            if (publisher == null)
            {
                var new_publisher = _publisherRepository.CreateEntity(new EPublisher()
                {
                    Name = input.PublisherName.Trim(),
                    CreatedDateTime = DateTime.Now
                });

                if (!String.IsNullOrEmpty(input.SeriesName))
                {
                    _seriesRepository.CreateEntity(new ESeries()
                    {
                        Name = input.SeriesName.Trim(),
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

        public bool IsEmpty(ImportObject data)
        {
            return String.IsNullOrEmpty(data.BookName) || String.IsNullOrEmpty(data.Publishdate) ||
                   String.IsNullOrEmpty(data.GenreName);
        }
    }
}
