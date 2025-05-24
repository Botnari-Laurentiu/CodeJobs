using CodeJobs.DataAccess;  
using CodeJobs.Domain.Entities; 
using System.Web.Mvc;

namespace CodeJobs.Controllers
{
    public class EmployerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployerController()
        {
            _context = new ApplicationDbContext();
        }

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

        // POST: /Employer/JobAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JobAdd(JobPost model)
        {
            if (ModelState.IsValid)
            {
                _context.JobPosts.Add(model);
                _context.SaveChanges();

                return RedirectToAction("JobsList");
            }
            return View("~/Views/Jobs/JobAdd.cshtml", model);
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