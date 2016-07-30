using Library.DataLayer.Entities;
using SenseFramework.Data.EntityFramework.Repositories;

namespace Library.DataLayer.Repositories.Publishers
{
    public interface IPublisherRepository : IRepository<EPublisher,int>
    {
        EPublisher GetPublisherByName(string name);
    }
}