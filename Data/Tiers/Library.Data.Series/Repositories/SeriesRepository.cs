using System;
using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Context;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Series.Repositories
{
    public class SeriesRepository : EfRepositoryBase<ESeries,int> , ISeriesRepository
    {
        public SeriesRepository(BaseContext dbContext) : base(dbContext)
        {
        }

        public ESeries CreateSeriesIfNotExists(string v, EPublisher publisher)
        {
            if (string.IsNullOrEmpty(v))
            {
                throw new ArgumentException("Name can not be empty", nameof(v));
            }

            return DbContext.Set<ESeries>().FirstOrDefault(x => x.Name == v) ?? CreateEntity(new ESeries {Name = v, Publisher = publisher, CreatedDateTime = DateTime.Now});

        }

        public ESeries GetSeriesbyName(string name)
        {
            return DbContext.Set<ESeries>().FirstOrDefault(x => x.Name == name);
        }
    }
}
