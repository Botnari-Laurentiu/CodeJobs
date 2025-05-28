using System.Threading.Tasks;
using System.Web.Mvc;
using CodeJobs.Domain.Entities;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.Business_Logic.Repositories;
using Microsoft.AspNet.Identity;

namespace CodeJobs.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobPostService _jobPostingService;

        public JobsController()
        {
            var repository = new JobPostRepository();
            _jobPostingService = new JobPostingService(repository);
        }

        // GET: /Jobs/JobsList
        public async Task<ActionResult> JobsList()
        {
            var jobs = await _jobPostingService.GetAllJobPosts();
            return View(jobs);
        }

        // GET: /Jobs/JobAdd
        public ActionResult JobAdd()
        {
            return View();
        }

        // POST: /Jobs/JobAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> JobAdd(JobPost model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = User.Identity.GetUserId();
                await _jobPostingService.CreateJobPost(model);
                return RedirectToAction("JobsList");
            }

            return View(model);
        }

        // GET: /Jobs/JobDetails/{id}
        public async Task<ActionResult> JobDetails(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var job = await _jobPostingService.GetJobPostById(id.Value);

            if (job == null)
                return HttpNotFound();

            return View(job);
        }
    }
}
