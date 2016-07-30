using System.Collections.Generic;

namespace Library.Business.Dtos
{
    public class RackOutputDto
    {

        public ICollection<RackDto> RackDtos { get; set; }

        public RackOutputDto()
        {
            RackDtos = new List<RackDto>();
        }
    }
}