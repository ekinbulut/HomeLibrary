using System.Data.Entity;
using System.Linq;
using Castle.Core.Logging;
using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Publishers
{
    public class PublisherRepository : EfRepositoryBase<EPublisher,int>, IPublisherRepository
    {
        public PublisherRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public EPublisher GetPublisherByName(string name)
        {
            return DbContext.Set<EPublisher>().FirstOrDefault(x => x.Name == name);
        }
    }
}
