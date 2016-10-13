using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CohortBuilderMVC.Controllers;
using Moq;
using ControllerAndRazorReview.DAL;
using System.Web.Mvc;
using ControllerAndRazorReview.DAL.Models;
using System.Collections.Generic;

namespace CohortBuilderMVC.Tests.Controllers
{
    [TestClass]
    public class CohortControllerTests
    {
        private Mock<CohortBuilder> mockCohortBuilder;
        private List<Cohort> cohorts;

        [TestInitialize]
        public void TestIntialize()
        {
            mockCohortBuilder = new Mock<CohortBuilder>();
            cohorts = new List<Cohort>();
            mockCohortBuilder.Setup(x => x.GetAllCohorts()).Returns(cohorts);
        }

        [TestCleanup]
        public void Cleanup()
        {
            mockCohortBuilder = null;
            cohorts = null;
        }

        [TestMethod]
        public void CanMakeInstanceOfCohortController()
        {
            CohortController controller = new CohortController();
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void CanMakeInstanceOfCohortController_WithCohortBuilder()
        {
            CohortController controller = new CohortController(mockCohortBuilder.Object);
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void CohortControllerCanReturnViewResult()
        {
            // Arrange
            CohortController controller = new CohortController(mockCohortBuilder.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CohortControllerCanReturnAllCohortsInIndex()
        {
            // Arrange
            CohortController controller = new CohortController(mockCohortBuilder.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var actualCohorts = result.ViewBag.Cohorts;

            // Assert
            CollectionAssert.AreEqual(cohorts, actualCohorts);
        }


    }
}
