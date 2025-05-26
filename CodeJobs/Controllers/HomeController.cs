using System.Threading.Tasks;
using System.Web.Mvc;
using CodeJobs.Domain.Interfaces;

namespace CodeJobs.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobPostService _jobPostService;

        public HomeController(IJobPostService jobPostService)
        {
            _jobPostService = jobPostService;
        }

        // GET: Home No Auth
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

        // ABOUT PAGE
        public ActionResult About()
        {
            return View("~/Views/StaticPages/About.cshtml");
        }

        // ABOUT CONTACT
        public ActionResult Contact()
        {
            return View("~/Views/StaticPages/Contact.cshtml");
        }

        // ABOUT TERMS
        public ActionResult Terms()
        {
            return View("~/Views/StaticPages/Terms.cshtml");
        }

        // ABOUT HELP
        public ActionResult Help()
        {
            return View("~/Views/StaticPages/Help.cshtml");
        }

        // ABOUT PRIVACY
        public ActionResult Privacy()
        {
            return View("~/Views/StaticPages/Privacy.cshtml");
        }
    }
}