using System.Web.Mvc;
using HangfireService.Services;

namespace HangfireService.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileBackgroundJob _fileBackgroundJob;
        public HomeController()
        {
            _fileBackgroundJob = new FileBackgroundJob();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// проверяем создание файла
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CreateFile(string id)
        {
            FilesService.CreateFile(id);

            return Content(id);
        }

        /// <summary>
        /// вызываем отложенное задание
        /// </summary>
        /// <returns></returns>
        public ActionResult Job()
        {
            var callTime = _fileBackgroundJob.DelayedCreation();

            return Content(callTime);
        }
    }
}