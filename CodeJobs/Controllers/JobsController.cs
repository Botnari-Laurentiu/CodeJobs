using System.Threading.Tasks;
using System.Web.Mvc;
using CodeJobs.Domain.Entities;
using CodeJobs.Business_Logic.Interfaces;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace CodeJobs.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobPostService _jobPostingService;
        private readonly IUserService _userService;

        public JobsController(IJobPostService jobPostingService, IUserService userService)
        {
            _jobPostingService = jobPostingService;
            _userService = userService;
        }

        // GET: /Jobs/JobsList
        public async Task<ActionResult> JobsList()
        {
            var jobs = await _jobPostingService.GetAllJobPosts();
            return View(jobs);
        }

        // GET: /Jobs/JobAdd
        [Authorize]
        public ActionResult JobAdd()
        {
            return View();
        }

        // POST: /Jobs/JobAdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> JobAdd(JobPost model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                model.UserId = userId;

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

        // GET: /Jobs/Search
        public async Task<ActionResult> Search(string query)
        {
            var jobs = await _jobPostingService.GetAllJobPosts();
            if (!string.IsNullOrWhiteSpace(query))
            {
                jobs = jobs
                    .Where(j => (j.Title != null && j.Title.ToLower().Contains(query.ToLower()))
                             || (j.Description != null && j.Description.ToLower().Contains(query.ToLower())))
                    .ToList();
            }
            return View("JobsList", jobs);
        }

        // GET: /Jobs/ManageJobs (Admin: manage all jobs)
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ManageJobs()
        {
            var jobs = await _jobPostingService.GetAllJobPosts();
            return View(jobs);
        }

        // GET: /Jobs/MyJobs (User: manage own jobs)
        [Authorize]
        public async Task<ActionResult> MyJobs()
        {
            var userId = User.Identity.GetUserId();
            var jobs = await _jobPostingService.GetJobPostsByUserId(userId);
            return View(jobs);
        }

        // GET: /Jobs/Edit/{id}
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var job = await _jobPostingService.GetJobPostById(id.Value);
            if (job == null)
                return HttpNotFound();

            // Allow admin or owner
            if (!User.IsInRole("Admin") && job.UserId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            return View(job);
        }

        // POST: /Jobs/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit(JobPost model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var job = await _jobPostingService.GetJobPostById(model.Id);
            if (job == null)
                return HttpNotFound();

            // Allow admin or owner
            if (!User.IsInRole("Admin") && job.UserId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            // Asigură-te că UserId nu se schimbă accidental
            model.UserId = job.UserId;

            await _jobPostingService.UpdateJobPost(model);

            // Redirect based on role
            if (User.IsInRole("Admin"))
                return RedirectToAction("ManageJobs");
            else
                return RedirectToAction("MyJobs");
        }

        // POST: /Jobs/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var job = await _jobPostingService.GetJobPostById(id);
            if (job == null)
                return HttpNotFound();

            // Allow admin or owner
            if (!User.IsInRole("Admin") && job.UserId != User.Identity.GetUserId())
                return new HttpUnauthorizedResult();

            await _jobPostingService.DeleteJobPost(id);

            // Redirect based on role
            if (User.IsInRole("Admin"))
                return RedirectToAction("ManageJobs");
            else
                return RedirectToAction("MyJobs");
        }
    }
}
