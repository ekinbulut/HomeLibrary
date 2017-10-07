using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Series.Repositories
{
    public interface ISeriesRepository : IRepository<ESeries,int>
    {
        ESeries GetSeriesbyName(string name);
    }
}