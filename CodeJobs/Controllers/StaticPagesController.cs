using System.Web.Mvc;

namespace CodeJobs.Controllers
{
    public class StaticPagesController : Controller
    {
        public ActionResult Terms()
        {
            return View();
        }
    }
}
