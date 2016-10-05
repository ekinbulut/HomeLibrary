﻿using System.ServiceModel;
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