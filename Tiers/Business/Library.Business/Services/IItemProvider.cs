using System.ServiceModel;
using Library.Business.Dtos;

namespace Library.Business.Services
{
    [ServiceContract(Namespace = "com.sense.business.Services", Name = "ItemProviderService")]
    public interface IItemProvider
    {
        [OperationContract]
        AuthorOutputDto Authors();
        [OperationContract]
        PublisherOutputDto Publishers();
        [OperationContract]
        GenreOutputDto Genres();
        [OperationContract]
        SeriesOutputDto Series();
        [OperationContract]
        ShelfOutputDto Shelfs();
        [OperationContract]
        RackOutputDto Racks();
    }
}
