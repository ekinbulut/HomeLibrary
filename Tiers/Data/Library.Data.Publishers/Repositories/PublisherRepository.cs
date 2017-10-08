using System;
using System.Data.Entity;
using System.Linq;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Context;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Publishers.Repositories
{
    public class PublisherRepository : EfRepositoryBase<EPublisher,int, PublisherContext>, IPublisherRepository
    {
        public PublisherRepository(PublisherContext dbContext) : base(dbContext)
        {
        }

        public EPublisher GetPublisherByName(string name)
        {
            return DbContext.Set<EPublisher>().FirstOrDefault(x => x.Name == name);
        }

        public EPublisher CreatePublisherIfNotExists(string name)
        {
            return DbContext.Set<EPublisher>().FirstOrDefault(x => x.Name == name) ??
                   CreateEntity(new EPublisher {Name = name,CreatedDateTime = DateTime.Now});
        }
    }
}
