using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.Data.Shelfs.Mappings
{
    public class EShelfConfiguration : EntityTypeConfigurationBase<EShelf,int>
    {
        public EShelfConfiguration():base("shelf")
        {
            Property(x => x.Name).HasMaxLength(15).IsRequired();
        }
    }
}