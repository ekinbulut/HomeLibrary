using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Series
{
    public class SeriesRepository : EfRepositoryBase<ESeries,int> , ISeriesRepository
    {
        public SeriesRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public ESeries GetSeriesbyName(string name)
        {
            return DbContext.Set<ESeries>().FirstOrDefault(x => x.Name == name);
        }
    }
}
