using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Series
{
    public interface ISeriesRepository : IRepository<ESeries,int>
    {
        ESeries GetSeriesbyName(string name);
    }
}