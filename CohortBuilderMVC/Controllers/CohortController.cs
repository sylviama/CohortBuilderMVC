using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CohortBuilderMVC.Controllers;
using ControllerAndRazorReview.DAL;


namespace CohortBuilderMVC.Controllers
{
    public class CohortController : Controller
    {
        private CohortBuilder _cohort { get; set; }

        public CohortController()
        {
            _cohort = new CohortController();
        }

        public CohortController(CohortBuilder cohort)
        {
            _cohort = cohort;
        }
            
        // GET: Cohort
        public ActionResult Index()
        {
            ViewBag.cohorts = _cohort.GetAllCohorts();
            return View();
        }
    }
}