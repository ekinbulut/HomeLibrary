using System.Collections.Generic;

namespace Library.Business.Services.Provider.Dtos
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