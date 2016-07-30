using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.DataLayer.Mappings
{
    class EShelfConfiguration : EntityTypeConfigurationBase<EShelf,int>
    {
        public EShelfConfiguration():base("shelf")
        {
            Property(x => x.Name).HasMaxLength(15).IsRequired();
        }
    }
}