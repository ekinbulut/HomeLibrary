using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.Data.Roles.Mappings
{
    public class ERoleConfiguration : EntityTypeConfigurationBase<ERole,int>
    {
        public ERoleConfiguration():base("Roles")
        {
            Property(x => x.Name).HasMaxLength(25).IsRequired();
        }
    }
}
