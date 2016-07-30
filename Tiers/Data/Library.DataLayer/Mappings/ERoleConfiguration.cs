using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.DataLayer.Mappings
{
    internal class ERoleConfiguration : EntityTypeConfigurationBase<ERole,int>
    {
        public ERoleConfiguration():base("Roles")
        {
            Property(x => x.Name).HasMaxLength(25).IsRequired();
        }
    }
}
