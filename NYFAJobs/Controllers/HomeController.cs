using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NYFAJobs.DAL;
using NYFAJobs.ViewModels;

namespace NYFAJobs.Controllers
{
    public class HomeController : Controller
    {
        private BoardContext db = new BoardContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<ApplicationGroup> data = from application in db.Applications
                                                   group application by application.CandidateID into applicationGroup
                                                   select new ApplicationGroup()
                                                   {
                                                       JobTitle = applicationGroup.Key.ToString(),
                                                       ApplicationCount = applicationGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}