using System.Collections.Generic;

namespace Library.Business.Services.Provider.Dtos
{
    public class GenreOutputDto
    {
        public ICollection<GenreDto> GenreDtos { get; set; }

        public GenreOutputDto()
        {
            GenreDtos = new List<GenreDto>();
        }
    }
}