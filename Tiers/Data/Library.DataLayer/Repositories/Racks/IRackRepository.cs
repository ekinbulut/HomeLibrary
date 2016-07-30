using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Racks
{
    public interface IRackRepository : IRepository<ERack,int>
    {
        ERack GetRackByRackNumber(int number);
    }
}