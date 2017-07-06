using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Library.Api.Objects
{
    [Serializable]
    [JsonObject(MemberSerialization.Fields)]
    public class BookOutputDto
    {
        public ICollection<BookDto> Books { get; set; }

        public int TotalBook { get; set; }

        public BookOutputDto()
        {
            Books = new List<BookDto>();
        }
    }
}