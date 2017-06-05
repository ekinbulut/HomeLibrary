using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Business.Services.Book.Dtos;
using Library.Business.Services.Integration.Dtos;
using Library.Mvc.Cache;
using Library.Mvc.Controllers;
using Library.Mvc.Models;

namespace Library.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        // GET: Home
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ActionResult Index()
        {

            if (CurrentUserModel.BookOutputDto == null)
            {
                var books = Services.BookServiceClient.GetBookListByUserId(CurrentUserModel.UserId);
                CurrentUserModel.BookOutputDto = books;

                if (!BookCache.Cache.Dictionary.ContainsKey(CurrentUserModel.Identity))
                {
                    BookCache.Cache.Dictionary.Add(CurrentUserModel.Identity,books);
                }

            }
            else
            {
                CurrentUserModel.BookOutputDto = BookCache.Cache.Dictionary[CurrentUserModel.Identity];
            }

           
            return View(CurrentUserModel);
        }

        public ActionResult BookList()
        {
            if (CurrentUserModel.BookOutputDto == null)
            {
                var books = Services.BookServiceClient.GetBookListByUserId(CurrentUserModel.UserId);
                CurrentUserModel.BookOutputDto = books;

                if (!BookCache.Cache.Dictionary.ContainsKey(CurrentUserModel.Identity))
                {
                    BookCache.Cache.Dictionary.Add(CurrentUserModel.Identity, books);
                }

            }
            else
            {
                CurrentUserModel.BookOutputDto = BookCache.Cache.Dictionary[CurrentUserModel.Identity];
            }

            return View(CurrentUserModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddBook()
        {

            return View(CurrentUserModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateWriter()
        {

            return View(CurrentUserModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult CreatePublisher()
        {

            return View(CurrentUserModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public ActionResult EditBookRecord(int bookId)
        {
            var bookdto = BookCache.Cache.Dictionary[CurrentUserModel.Identity].Books.FirstOrDefault(x => x.Id == bookId);
            CurrentUserModel.BookDto = bookdto;

            return View(CurrentUserModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public ActionResult DeleteBookRecord(int bookId)
        {
            var bookdto = BookCache.Cache.Dictionary[CurrentUserModel.Identity].Books.FirstOrDefault(x => x.Id == bookId);

            if (Services.BookServiceClient.DeleteBook(bookdto))
            {
                BookCache.Cache.Dictionary.Clear();

                CurrentUserModel.BookOutputDto = null;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        #region [ POST METHODs]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBook(UserModel model)
        {

            var isCreated = Services.BookServiceClient.AddBook(new BookInputDto
            {

                Name = model.BookModel.Name,
                SkinType = model.BookModel.SkinType,
                Serie = model.BookModel.Serie,
                Genre = model.BookModel.Genre,
                PublishDate = model.BookModel.PublishDate,
                No = model.BookModel.No,
                Author = model.BookModel.Author,
                Rack = model.BookModel.Rack,
                Publisher = model.BookModel.Publisher,
                Shelf = model.BookModel.Shelf,
                UserId = CurrentUserModel.UserId
            });

            if (isCreated)
            {
                BookCache.Cache.Dictionary.Clear();

                CurrentUserModel.BookOutputDto = null;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("AddBook", "Home");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateWriter(UserModel model)
        {
            var result = Services.IntegrationServiceClient.CreateAuthor(new AuthorInputDto
            {
                AuthorDto = new AuthorDto
                {
                    Name = model.AuthorModel.Name
                }
            });

            if (result)
            {
                return RedirectToAction("AddBook", "Home");
            }

            //CurrentUserModel = Session["Information"] as CurrentUserModel;

            return View(CurrentUserModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreatePublisher(UserModel model)
        {
            var result = Services.IntegrationServiceClient.CreatePublisher(new PublisherInputDto
            {
                PublisherName = model.PublisherModel.PublisherName,
                SeriesName = model.PublisherModel.SeriesName
            });


            if (result)
            {
                return RedirectToAction("AddBook", "Home");
            }

            //CurrentUserModel = Session["Information"] as CurrentUserModel;

            return View(CurrentUserModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditBookRecord(UserModel model)
        {
            var isUpdated = Services.BookServiceClient.UpdateBook(model.BookDto);

            if (isUpdated)
            {
                BookCache.Cache.Dictionary.Clear();

                CurrentUserModel.BookOutputDto = null;

                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("EditBookRecord", "Home");
        }

        #endregion
    }
}