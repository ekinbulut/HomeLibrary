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
            
            Usermodel = Session["Information"] as UserModel;

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

            Usermodel = Session["Information"] as UserModel;
            
            return View(Usermodel);
        }


        [HttpPost]
        public ActionResult AddBook(UserModel model)
        {
            Usermodel = Session["Information"] as UserModel;

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

        public ActionResult CreateWriter()
        {

            Usermodel = Session["Information"] as UserModel;

            return View(Usermodel);
        }

        public ActionResult CreatePublisher()
        {

            Usermodel = Session["Information"] as UserModel;

            return View(Usermodel);
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

    }
}