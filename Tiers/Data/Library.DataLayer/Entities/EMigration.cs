using SenseFramework.Data.EntityFramework.EntityBases;

namespace Library.DataLayer.Entities
{
    public class EMigration : Entity<int>
    {
        public string Name { get; set; }
    }
}