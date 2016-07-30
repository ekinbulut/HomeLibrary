using System.ServiceModel;
using Library.Business.Dtos;

namespace Library.Business.Services
{
    [ServiceContract(Namespace = "com.sense.services.Services", Name = "BookService")]
    public interface IBookService
    {
        [OperationContract]
        BookOutputDto GetBookList();

        [OperationContract]
        bool AddBook(BookInputDto input);

        [OperationContract]
        bool UpdateBook(BookDto input);
    }
}
