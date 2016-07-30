using System.Collections.Generic;

namespace Library.Business.Dtos
{
    public class AuthorOutputDto
    {
        public ICollection<AuthorDto> AuthorDtos { get; set; }

        public AuthorOutputDto()
        {
            AuthorDtos = new List<AuthorDto>();
        }
    }
}