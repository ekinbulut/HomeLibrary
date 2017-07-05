using System;
using System.Collections.Generic;

namespace Library.Api.Objects
{
    [Serializable]
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