using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Library.Business.Services.Integration.Dtos;
using Library.Mvc.Cache;
using Library.Mvc.Controllers;
using Library.Mvc.Helpers;

namespace Library.Web.Controllers
{
    [Authorize]
    public class IntegrationController : BaseController
    {
        public override ActionResult Index()
        {
            return View(CurrentUserModel);
        }

        /// <summary>
        /// File upload to server it sends file to server
        /// </summary>
        /// <param name="filetoupload"></param>
        /// <returns></returns>
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
                        UserId = CurrentUserModel.UserId
                    }
                });

                if (result)
                {
                    BookCache.Cache.Dictionary.Clear();
                    CurrentUserModel.BookOutputDto = null;

                    return RedirectToAction("Index", "Home");
                }

                return RedirectToAction("Index", "Integration");
            }

            return RedirectToAction("Index", "Integration");



        }

        /// <summary>
        /// Download template folder
        /// </summary>
        /// <returns></returns>
        public FileResult DownloadTemplateFile()
        {
            var templateMap = Server.MapPath("~/Template");
            byte[] fileBytes = System.IO.File.ReadAllBytes($"{templateMap}/Template.xlsx");
            string fileName = "book_template.xlsx";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}