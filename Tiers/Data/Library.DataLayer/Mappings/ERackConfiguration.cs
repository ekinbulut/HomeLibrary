using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.DataLayer.Mappings
{
    class ERackConfiguration : EntityTypeConfigurationBase<ERack,int>
    {
        public ERackConfiguration():base("Rack")
        {
            Property(x => x.RackNumber).IsRequired();

            HasMany(x => x.Shelfs).WithMany(x => x.Racks).Map(cs =>
            {
                cs.MapLeftKey("RackRefId");
                cs.MapRightKey("ShelfRefId");
                cs.ToTable("XXX_SHELF_RACK");
            });
        }
    }
}
