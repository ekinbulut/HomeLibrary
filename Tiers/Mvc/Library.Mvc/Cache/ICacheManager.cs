using System;
using System.Collections.Generic;

namespace Library.Mvc.Cache
{
    public interface ICacheManager<T> where T : class
    {
        IDictionary<Guid,T> Dictionary { get; set; }
        T GetCachedObjects(Guid key);
    }
}