using System.Web.Mvc;

namespace CodeJobs.Controllers
{
    public class EmployerController : Controller
    {
        // GET: /Employer/JobsList
        public ActionResult JobsList()
        {
            return View("~/Views/Jobs/JobsList.cshtml");
        }

        // GET: /Employer/JobAdd
        public ActionResult JobAdd()
        {
            return View("~/Views/Jobs/JobAdd.cshtml");
        }

        // GET: /Employer/JobDetails/{id}
        public ActionResult JobDetails(int? id)
        {

            return View("~/Views/Jobs/JobDetails.cshtml");
        }

        // GET: /Employer/MyProfile
        public ActionResult MyProfile()
        {
            return View("~/Views/Jobs/MyProfile.cshtml");
        }
    }
}

