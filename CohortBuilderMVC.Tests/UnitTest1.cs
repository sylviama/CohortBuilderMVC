using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using CohortBuilderMVC.Controllers;
using Moq;
using ControllerAndRazorReview.DAL;
using ControllerAndRazorReview.DAL.Models;
using System.Collections.Generic;

namespace CohortBuilderMVC.Tests
{
    [TestClass]
    public class CohortControllerTest
    {
        private Mock<CohortBuilder> mockCohortBuilder;
        private List<Cohort> cohorts;

        [TestInitialize]
        public void TestInitialize()
        {
            mockCohortBuilder = new Mock<CohortBuilder>();
            cohorts = new List<Cohort>();
            mockCohortBuilder.Setup(x => x.GetAllCohorts()).Returns(cohorts);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            mockCohortBuilder = null;
            cohorts = null;
        }

        [TestMethod]
        public void CanMakeInstanceOfCohortController()
        {

        }
        [TestMethod]
        public void canMakeInstanceOfCohortController_withCohortBuilder()
        {
            CohortController controller = new CohortController();
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void CohortControllerCouldReturnView()
        {
            CohortController controller = new CohortController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CohortControllerCanReturnAllCohortsInIndex()
        {
            CohortController controller = new CohortController(mockCohortBuilder.Object);
            ViewResult result = controller.Index() as ViewResult;
            var actualCohorts = result.ViewBag.Cohorts;

            CollectionAssert.AreEqual(actualCohorts, cohorts);
        }
    }
}
