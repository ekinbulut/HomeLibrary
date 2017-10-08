using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Racks.Repositories
{
    public interface IRackRepository : IRepository<ERack,int>
    {
        ERack GetRackByRackNumber(int number);
    }
}