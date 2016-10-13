using ControllerAndRazorReview.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CohortBuilderMVC.Controllers
{
    public class CohortController : Controller
    {
        private CohortBuilder cohortBuilder { get; set; }

        public CohortController()
        {
            cohortBuilder = new CohortBuilder();
        }

        public CohortController(CohortBuilder builder)
        {
            cohortBuilder = builder;
        }
        
        // GET: Cohort
        public ActionResult Index()
        {
            ViewBag.Cohorts = cohortBuilder.GetAllCohorts();
            return View();
        }
    }
}