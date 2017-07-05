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
        /// <param name="minutesAmount">на сколько минут отложить задачу</param>
        /// <returns>Job identifier</returns>
        public ActionResult Job(int minutesAmount)
        {
            return Content(_fileBackgroundJob.DelayedCreation(minutesAmount));
        }

        /// <summary>
        /// Удалить отложенную задачу
        /// </summary>
        /// <param name="jobId">идентификатор задачи</param>
        /// <returns>True on a successfull state transition, false otherwise.</returns>
        public ActionResult RemoveJob(string jobId)
        {
            return Content(_fileBackgroundJob.RemoveDelayedJob(jobId) ? "Successfuly deleted" : "Some problem happend during deletion");
        }


    }
}