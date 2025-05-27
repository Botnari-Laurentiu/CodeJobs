using System.Threading.Tasks;
using System.Web.Mvc;
using CodeJobs.Business_Logic.Interfaces;
using CodeJobs.Business_Logic.Core.Services; 

namespace CodeJobs.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobPostService _jobPostService;

        public HomeController()
        {
            _jobPostService = new JobPostingService(); // Initialize the service
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> HomeAuth()
        {
            var jobPosts = await _jobPostService.GetAllJobPosts();
            return View(jobPosts);
        }

        public ActionResult About()
        {
            return View("~/Views/StaticPages/About.cshtml");
        }

        public ActionResult Contact()
        {
            return View("~/Views/StaticPages/Contact.cshtml");
        }

        public ActionResult Terms()
        {
            return View("~/Views/StaticPages/Terms.cshtml");
        }

        public ActionResult Help()
        {
            return View("~/Views/StaticPages/Help.cshtml");
        }

        public ActionResult Privacy()
        {
            return View("~/Views/StaticPages/Privacy.cshtml");
        }
    }
}