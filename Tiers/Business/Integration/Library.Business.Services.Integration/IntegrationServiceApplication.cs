using System;
using System.Configuration;
using System.Data;
using System.IO;
using Castle.Core.Logging;


namespace Library.Business.Services.Integration
{
using Dtos;
using Model;
using Parser;
using Validations;
using Library.Data.Entities;
using Library.Data.Entities.Enums;
using Library.Data.Books.Repositories;
using Library.Data.Author.Repositories.Authors;
using Library.Data.Publishers.Repositories;
using Library.Data.Genres.Repositories;
using Library.Data.Shelfs.Repositories;
using Library.Data.Racks.Repositories;
using Library.Data.Users.Repositories;
using Library.Data.Series.Repositories;
using Library.Common;

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
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly IImporter _importer;
        private readonly IFileReciever _fileReciever;

        public IntegrationServiceApplication(IParserApplication parserApplication, IBookRepository bookRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository, IGenreRepository genreRepository, ISeriesRepository seriesRepository, IShelfRepository shelfRepository, IRackRepository rackRepository, ILogger logger, IUserRepository userRepository, IImporter importer, IFileReciever fileReciever)
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
            _fileReciever = fileReciever;
        }

        /// <summary>
        /// Imports the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public bool Import(ImportInputDto input)
        {
            ImportObjectValidaiton validator = new ImportObjectValidaiton();

            DataTable datatable = _parserApplication.ReadExcelFile(input.ImportDto.Input);

            EUser user = _userRepository.GetOne(input.ImportDto.UserId);
            bool recordInserted = false;

            foreach (DataRow row in datatable.Rows)
            {
                ImportObject importerObject = _importer.ConvertRowIntoImportObject(row);
                importerObject.User = user;

                var result = validator.Validate(importerObject);
                if (!result.IsValid) continue;

                recordInserted = InsertBookRecord(importerObject);

                if (!recordInserted) break;
            }

            return recordInserted;

        }

        private bool InsertBookRecord(ImportObject importerObject)
        {

            try
            {
                ImportObject importerObj = importerObject;
                bool exists = _bookRepository.CheckIfBookExistsByNameWriterAndByPublisher(importerObj.BookName, importerObj.AuthorName, importerObj.PublisherName);

                EBook book = new EBook();

                if (!exists)
                {
                     GenerateBookRecord(importerObj, ref book);

                    _bookRepository.CreateEntity(book);
                }
                else
                {
                    book = _bookRepository.GetBookByNameAndByPublisher(importerObj.BookName, importerObj.AuthorName, importerObj.PublisherName);

                    if (!book.Users.Contains(importerObj.User))
                    {
                        book.Users.Add(importerObj.User);
                        _bookRepository.UpdateEntity(book);
                    }
                }

                return true;
            }
            catch (Exception error)
            {
                _logger.Error("Integration Error while doing InsertBookRecord", error);

                return false;
            }

        }

        private void GenerateBookRecord(ImportObject importerObj, ref EBook book)
        {
            book.Author = _authorRepository.CreateIfAuthorIsNotExists(importerObj.AuthorName);
            book.Publisher = _publisherRepository.CreatePublisherIfNotExists(importerObj.PublisherName);
            book.Genre = _genreRepository.CreateGenreIfNotExists(importerObj.GenreName);
            book.Serie = _seriesRepository.CreateSeriesIfNotExists(importerObj.SerieName, book.Publisher);
            book.Rack = _rackRepository.GetRackByRackNumber(int.Parse(importerObj.RackId));
            book.Shelf = _shelfRepository.GetShelfById(int.Parse(importerObj.ShelfId));

            book.Name = importerObj.BookName;
            book.PublishDate = int.Parse(importerObj.Publishdate);
            book.No = ConvertToRomanIntegers(importerObj.No);
            book.SkinType = importerObj.Skintype.Equals("ciltli", StringComparison.InvariantCulture) ? SkinType.Ciltli : SkinType.Ciltsiz;
            book.CreatedDateTime = DateTime.Now;
            book.Users.Add(importerObj.User);
        }

        private int? ConvertToRomanIntegers(string number)
        {
            return !string.IsNullOrEmpty(number) ? (int.TryParse(number, out int no) ? no : number.RomanToInteger()) : null;
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

            var result = _authorRepository.CreateEntity(new EAuthor
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

            // if publisher exist but needs to bind series to it
            if (publisher != null)
            {
                if (!String.IsNullOrEmpty(input.SeriesName))
                {
                    var result = _seriesRepository.CreateEntity(new ESeries
                    {
                        Name = input.SeriesName.Trim(),
                        Publisher = publisher,
                        CreatedDateTime = DateTime.Now

                    });

                    return result != null;
                }
            }
            else
            {
                // if publisher is not exist create new publisher
                var newPublisher = _publisherRepository.CreateEntity(new EPublisher
                {
                    Name = input.PublisherName.Trim(),
                    CreatedDateTime = DateTime.Now
                });

                // if series is not null bind to created publisher
                if (!String.IsNullOrEmpty(input.SeriesName))
                {
                    _seriesRepository.CreateEntity(new ESeries
                    {
                        Name = input.SeriesName.Trim(),
                        Publisher = newPublisher,
                        CreatedDateTime = DateTime.Now

                    });
                }

                return newPublisher != null;

            }

            return false;
        }

        /// <summary>
        /// Recieves the bytearray of the document and creates it on the server side.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>True or false</returns>
        public bool SendFile(IntegrationInputDto input)
        {
            var docname = input.IntegrationDto.DocName;
            var path = ConfigurationManager.AppSettings["UploadFile"];

            if (!_fileReciever.ValidatePath(path)) return false;

            if (string.IsNullOrEmpty(path))
            {
                _fileReciever.CreateFolder(path);
            }

            var strdocPath = Path.Combine(path, docname);

            bool isFileRecieved = _fileReciever.RecieveFile(strdocPath, input.IntegrationDto.ByteArray);

            return isFileRecieved && Import(new ImportInputDto()
            {
                ImportDto = new ImportDto()
                {
                    UserId = input.IntegrationDto.UserId,
                    Input = strdocPath
                }
            });
        }

    }
}
