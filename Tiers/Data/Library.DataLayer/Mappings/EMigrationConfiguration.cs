using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.TypeConfigurationBase;

namespace Library.DataLayer.Mappings
{
    class EMigrationConfiguration : EntityTypeConfigurationBase<EMigration, int>
    {
        public EMigrationConfiguration():base("Migrations")
        {
           Property(x => x.Name).HasMaxLength(25);
            //ToTable("Migrations");
        }
    }

}
