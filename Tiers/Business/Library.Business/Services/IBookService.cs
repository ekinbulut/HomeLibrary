using System.ServiceModel;
using Library.Business.Dtos;

namespace Library.Business.Services
{
    [ServiceContract(Namespace = "com.sense.services.Services", Name = "BookService")]
    public interface IBookService
    {
        /// <summary>
        /// Gets the book list.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        BookOutputDto GetBookList();

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [OperationContract]
        bool AddBook(BookInputDto input);

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateBook(BookDto input);
    }
}
