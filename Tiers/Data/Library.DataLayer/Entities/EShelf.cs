using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace Library.Data.Entities
{
    public class EShelf : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual ICollection<ERack> Racks { get; set; }
        public virtual ICollection<EBook> Books { get; set; }

        public EShelf()
        {
            Racks = new List<ERack>();
            Books = new List<EBook>();
        }
    }
}