using System.Collections.Generic;

namespace Library.Business.Dtos
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