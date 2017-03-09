using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace Library.Data.Entities
{
    public class ERack : Entity<int>
    {
        public virtual int RackNumber { get; set; }
        public virtual ICollection<EShelf> Shelfs { get; set; }
        public virtual ICollection<EBook> Books { get; set; }
    }
}