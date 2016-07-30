using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Migrations
{
    public interface IMigrationRepository : IRepository<EMigration,int>
    {
    }
}