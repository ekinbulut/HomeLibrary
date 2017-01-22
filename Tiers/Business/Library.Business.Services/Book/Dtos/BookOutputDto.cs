using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.Business.Services.Book.Dtos
{
    [DataContract]
    [Serializable]
    public class BookOutputDto
    {
        [DataMember]
        public ICollection<BookDto> Books { get; set; }

        public BookOutputDto()
        {
            Books = new List<BookDto>();
        }
    }
}