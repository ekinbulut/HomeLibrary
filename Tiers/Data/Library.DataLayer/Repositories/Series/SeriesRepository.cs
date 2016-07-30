using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Series
{
    public class SeriesRepository : EfRepositoryBase<ESeries,int> , ISeriesRepository
    {
        public SeriesRepository(DbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public ESeries GetSeriesbyName(string name)
        {
            return DbContext.Set<ESeries>().FirstOrDefault(x => x.Name == name);
        }
    }
}
