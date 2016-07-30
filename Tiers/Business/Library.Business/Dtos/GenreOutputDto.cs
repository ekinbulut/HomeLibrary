using System.Collections.Generic;

namespace Library.Business.Dtos
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