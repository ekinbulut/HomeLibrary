using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.DataLayer.Mappings
{
    class ESeriesConfiguration : EntityTypeConfigurationBase<ESeries,int>
    {
        public ESeriesConfiguration():base("Series")
        {
            Property(x => x.Name).HasMaxLength(75).IsOptional();

            HasRequired(x => x.Publisher).WithMany(x => x.Series).HasForeignKey(x => x.PublisherId);
        }
    }
}