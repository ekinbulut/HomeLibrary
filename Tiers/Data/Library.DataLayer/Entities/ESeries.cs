using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace Library.DataLayer.Entities
{
    public class ESeries : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual EPublisher Publisher { get; set; }
        public virtual int PublisherId { get; set; }
        public virtual ICollection<EBook> Books { get; set; }

        public ESeries()
        {
            Books = new List<EBook>();
        }
    }
}