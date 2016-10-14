using System.Collections.Generic;

namespace Library.Business.Services.Provider.Dtos
{
    public class PublisherOutputDto
    {
        public ICollection<PublisherDto> PublisherDtos { get; set; }

        public PublisherOutputDto()
        {
            PublisherDtos = new List<PublisherDto>();
        }
    }
}