using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Series
{
    public interface ISeriesRepository : IRepository<ESeries,int>
    {
        ESeries GetSeriesbyName(string name);
    }
}