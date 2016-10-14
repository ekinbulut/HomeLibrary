using System;
using System.Collections.Generic;
using Library.Business.Services.Book.Dtos;


namespace Library.Mvc.Cache
{
    public class BookCache : ICacheManager<BookOutputDto>
    {
        private static BookCache _cacheManager;
        public IDictionary<Guid, BookOutputDto> Dictionary { get; set; }

        public BookCache()
        {
            Dictionary = new Dictionary<Guid, BookOutputDto>();
        }

        public static BookCache Cache
        {
            get
            {
                if (_cacheManager != null)
                {
                    return _cacheManager;
                }

                return _cacheManager = new BookCache();
            }
        }

        public BookOutputDto GetCachedObjects(Guid key)
        {
            return Dictionary[key];
        }
    }
}
