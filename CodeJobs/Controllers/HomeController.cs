using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeJobs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home No Auth
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home Auth
        public ActionResult HomeAuth()
        {
            return View();
        }
    }
}