using System.Collections.Generic;

namespace Library.Business.Services.Provider.Dtos
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