using System.Collections.Generic;
using SenseFramework.Data.EntityFramework.EntityBases;

namespace Library.Data.Athentication.Entities
{
    public class ERole : Entity<int>
    {
        public virtual string Name { get; set; }
        public virtual ICollection<EUser> Users { get; set; }

        public ERole()
        {
            Users = new List<EUser>();
        }

    }
}