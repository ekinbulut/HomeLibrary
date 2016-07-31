using System.ServiceModel;
using Library.Business.Dtos;

namespace Library.Business.Services
{
    [ServiceContract(Namespace = "com.sense.business.Services", Name = "ItemProviderService")]
    public interface IItemProvider
    {
        /// <summary>
        /// Authorses this instance.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        AuthorOutputDto Authors();

        /// <summary>
        /// Publisherses this instance.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        PublisherOutputDto Publishers();

        /// <summary>
        /// Genreses this instance.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        GenreOutputDto Genres();

        /// <summary>
        /// Serieses this instance.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        SeriesOutputDto Series();

        /// <summary>
        /// Shelfses this instance.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ShelfOutputDto Shelfs();

        /// <summary>
        /// Rackses this instance.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        RackOutputDto Racks();
    }
}
