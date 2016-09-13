using Library.Data.Athentication.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.Data.Athentication.TypeMappings
{
    public class ERoleConfiguration : EntityTypeConfigurationBase<ERole,int>
    {
        public ERoleConfiguration():base("Roles")
        {
            Property(x => x.Name).HasMaxLength(25).IsRequired();
        }
    }
}
