using System.Collections.Generic;

namespace Library.Business.Services.Provider.Dtos
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