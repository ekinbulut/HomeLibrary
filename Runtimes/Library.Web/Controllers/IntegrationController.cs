using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Library.Mvc.Cache;
using Library.Mvc.Controllers;
using Library.Mvc.IntegrationServices;
using Library.Mvc.Models;


namespace Library.Web.Controllers
{
    public class IntegrationController : BaseController
    {
        public override ActionResult Index()
        {
            if (Session["Information"] == null)
            {
                return RedirectToAction("Index", "Authentication");
            }

            Usermodel = Session["Information"] as UserModel;

            return View(Usermodel);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase filetoupload)
        {
            if (filetoupload != null)
            {
                var configpath = ConfigurationManager.AppSettings["UploadFolderName"];

                string file = Path.GetFileName(filetoupload.FileName);
                var path = Path.Combine(Server.MapPath("~/" + configpath), file);
                filetoupload.SaveAs(path);

                var fullpath = Path.GetFullPath(path);

                var result = Services.IntegrationServiceClient.Import(new IntegrationInputDto()
                {
                    IntegrationDto = new IntegrationDto()
                    {
                        FilePath = fullpath
                    }
                });

                if (result)
                {
                    BookCache.Cache.Dictionary.Clear();
                    Usermodel = Session["Information"] as UserModel;
                    Usermodel.BookOutputDto = null;

                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", "Integration");
            }

            return RedirectToAction("Index", "Integration");



        }
    }
}