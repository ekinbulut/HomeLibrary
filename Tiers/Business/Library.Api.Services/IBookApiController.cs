using Library.Api.Objects;

namespace Library.Api.Services
{
    public interface IBookApiController
    {
        /// <summary>
        /// Gets the book list.
        /// </summary>
        /// <returns></returns>
        BookOutputDto GetBookList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        BookOutputDto GetBookListByUserId(int userId);

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        bool AddBook(BookInputDto input);

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        bool UpdateBook(BookDto input);

        /// <summary>
        /// Deletes book record with Id
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool DeleteBook(BookDto input);

        /// <summary>
        /// Returns books in a range
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        BookOutputDto GetBooksRangeBy(int start, int length, int userId);


        /// <summary>
        /// Returns record in search
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        BookOutputDto GetBooksSearchRangeBy(int start, int length, string searchKey, int userId);
    }
}