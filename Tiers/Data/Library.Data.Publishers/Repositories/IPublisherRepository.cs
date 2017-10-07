using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Publishers.Repositories
{
    public interface IPublisherRepository : IRepository<EPublisher,int>
    {
        EPublisher GetPublisherByName(string name);
        EPublisher CreatePublisherIfNotExists(string name);
    }
}