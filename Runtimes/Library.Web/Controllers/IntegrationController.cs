using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Library.Business.Services.Integration.Dtos;
using Library.Mvc.Cache;
using Library.Mvc.Controllers;
using Library.Mvc.Helpers;
using Library.Mvc.Models;

namespace Library.Web.Controllers
{
    public class IntegrationController : BaseController
    {
        public override ActionResult Index()
        {
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

                var mybytearray = StreamOperator.GetBytes(fullpath);

                var result = Services.IntegrationServiceClient.SendFile(new IntegrationInputDto
                {
                    IntegrationDto = new IntegrationDto
                    {
                        ByteArray = mybytearray,
                        DocName = file,
                        UserId = Usermodel.UserId
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