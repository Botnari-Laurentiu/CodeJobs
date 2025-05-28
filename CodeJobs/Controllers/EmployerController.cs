using System.Threading.Tasks;
using System.Web.Mvc;
using CodeJobs.Domain.Entities;
using CodeJobs.Business_Logic.Core.Services;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.Business_Logic.Repositories; 

namespace CodeJobs.Controllers
{
    public class EmployerController : Controller
    {
        private readonly IJobPostService _jobPostingService;

        public EmployerController()
        {
            var repository = new JobPostRepository();
            _jobPostingService = new JobPostingService(repository);
        }

        // POST <--JobList-->
        public async Task<ActionResult> JobsList()
        {
            var jobs = await _jobPostingService.GetAllJobPosts();
            return View("~/Views/Jobs/JobsList.cshtml", jobs);
        }

        // GET: /Employer/JobAdd
        public ActionResult JobAdd()
        {
            return View("~/Views/Jobs/JobAdd.cshtml");
        }

        // POST: /Employer/JobAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> JobAdd(JobPost model)
        {
            if (ModelState.IsValid)
            {
                await _jobPostingService.CreateJobPost(model);
                return RedirectToAction("JobsList");
            }

            return View("~/Views/Jobs/JobAdd.cshtml", model);
        }

        // POST <--JobDetails-->
        public async Task<ActionResult> JobDetails(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var job = await _jobPostingService.GetJobPostById(id.Value);

            if (job == null)
                return HttpNotFound();

            return View("~/Views/Jobs/JobDetails.cshtml", job);
        }

        // GET: /Employer/MyProfile
        public ActionResult MyProfile()
        {
            return View("~/Views/Jobs/MyProfile.cshtml");
        }
    }
}
