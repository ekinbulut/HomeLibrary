using System.Collections.Generic;

namespace Library.Business.Dtos
{
    public class ShelfOutputDto
    {
        public ICollection<ShelfDto> ShelfDtos { get; set; }

        public ShelfOutputDto()
        {
            ShelfDtos = new List<ShelfDto>();
        }
    }
}