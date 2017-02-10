using System.ServiceModel;
using Library.Business.Services.Book.Dtos;

namespace Library.Business.Services.Book
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
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        BookOutputDto GetBookListByUserId(int userId);

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

        /// <summary>
        /// Deletes book record with Id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteBook(BookDto input);
    }
}
