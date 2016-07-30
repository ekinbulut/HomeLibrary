using System.Collections.Generic;

namespace Library.Business.Dtos
{
    public class SeriesOutputDto
    {
        public ICollection<SeriesDto> SeriesDtos { get; set; }

        public SeriesOutputDto()
        {
            SeriesDtos = new List<SeriesDto>();
        }
    }
}