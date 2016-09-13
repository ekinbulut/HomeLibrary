using Library.Data.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.Data.Repositories.Publishers
{
    public interface IPublisherRepository : IRepository<EPublisher,int>
    {
        EPublisher GetPublisherByName(string name);
    }
}