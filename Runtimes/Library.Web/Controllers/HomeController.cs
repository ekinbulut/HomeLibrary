using System.Linq;
using System.Web.Mvc;
using Library.Business.Services.Book.Dtos;
using Library.Business.Services.Integration.Dtos;
using Library.Mvc.Cache;
using Library.Mvc.Controllers;
using Library.Mvc.Models;

namespace Library.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public override ActionResult Index()
        {

            if (Usermodel.BookOutputDto == null)
            {
                var books = Services.BookServiceClient.GetBookListByUserId(Usermodel.UserId);
                Usermodel.BookOutputDto = books;


                BookCache.Cache.Dictionary.Add(Usermodel.Identity,books);

            }
            else
            {
                Usermodel.BookOutputDto = BookCache.Cache.Dictionary[Usermodel.Identity];
            }


            return View(Usermodel);
        }

        public ActionResult AddBook()
        {

            return View(Usermodel);
        }

        public ActionResult CreateWriter()
        {

            return View(Usermodel);
        }

        public ActionResult CreatePublisher()
        {

            return View(Usermodel);
        }

        public ActionResult EditBookRecord(int bookId)
        {
            var bookdto = BookCache.Cache.Dictionary[Usermodel.Identity].Books.FirstOrDefault(x => x.Id == bookId);
            Usermodel.BookDto = bookdto;

            return View(Usermodel);
        }

        public ActionResult DeleteBookRecord(int bookId)
        {
            var bookdto = BookCache.Cache.Dictionary[Usermodel.Identity].Books.FirstOrDefault(x => x.Id == bookId);

            if (Services.BookServiceClient.DeleteBook(bookdto))
            {
                BookCache.Cache.Dictionary.Clear();

                Usermodel.BookOutputDto = null;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

#region POST 

        [HttpPost]
        public ActionResult AddBook(UserModel model)
        {

            var isCreated = Services.BookServiceClient.AddBook(new BookInputDto()
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
                UserId = Usermodel.UserId
            });

            if (isCreated)
            {
                BookCache.Cache.Dictionary.Clear();

                Usermodel.BookOutputDto = null;

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("AddBook", "Home");
        }

        [HttpPost]
        public ActionResult CreateWriter(UserModel model)
        {
            var result = Services.IntegrationServiceClient.CreateAuthor(new AuthorInputDto()
            {
                AuthorDto = new AuthorDto()
                {
                    Name = model.AuthorModel.Name
                }
            });

            if (result)
            {
                return RedirectToAction("Index", "Home");
            }

            Usermodel = Session["Information"] as UserModel;

            return View(Usermodel);
        }

        [HttpPost]
        public ActionResult CreatePublisher(UserModel model)
        {
            var result = Services.IntegrationServiceClient.CreatePublisher(new PublisherInputDto()
            {
                PublisherName = model.PublisherModel.PublisherName,
                SeriesName = model.PublisherModel.SeriesName
            });


            if (result)
            {
                return RedirectToAction("Index", "Home");
            }

            Usermodel = Session["Information"] as UserModel;

            return View(Usermodel);
        }

        [HttpPost]
        public ActionResult EditBookRecord(UserModel model)
        {
            var isUpdated = Services.BookServiceClient.UpdateBook(model.BookDto);

            if (isUpdated)
            {
                BookCache.Cache.Dictionary.Clear();

                Usermodel.BookOutputDto = null;

                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("EditBookRecord", "Home");
        }

#endregion
    }
}