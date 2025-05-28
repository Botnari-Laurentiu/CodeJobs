using CodeJobs.Business_Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CodeJobs.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobPostService _jobPostService;

        public JobsController()
        {
            _jobPostService = new JobPostingService();
        }

        public async Task<ActionResult> JobsList()
        {
            var jobs = await _jobPostService.GetAllJobPosts();
            return View(jobs);
        }
    }
}
