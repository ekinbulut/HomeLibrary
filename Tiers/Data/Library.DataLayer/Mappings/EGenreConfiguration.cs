using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.DataLayer.Mappings
{
    class EGenreConfiguration : EntityTypeConfigurationBase<EGenre,int>
    {
        public EGenreConfiguration(): base("Genre")
        {
            Property(x => x.Genre).IsRequired().HasMaxLength(35);
        }
    }
}
