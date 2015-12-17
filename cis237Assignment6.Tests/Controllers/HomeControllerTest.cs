using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cis237Assignment6;
using cis237Assignment6.Controllers;

namespace cis237Assignment6.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }



        // Not quite sure how to test, even despite being shown it in class, so starting simple.
        [TestMethod]
        public void MyContactTest()
        {
            // Create controller which will handle this page to test.
            HomeController controller = new HomeController();

            // Navigate to page? I think?
            ViewResult result = controller.Contact() as ViewResult;

            // Attempt to verify that text on contact page is actually present?
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);

            // Test email attempt.
            //Assert.AreSame("mailto:Aaa@a.aaa", result.Equals(???)
            // How do you do something as simple as testing to make sure a link points to the correct thing?
            // Two hours of trying to google unit tests to figure it out and I still don't understand.
            // I really wish we covered testing more indepth starting from the very first program.
            // I understand the general concepts of it, but have no idea how to actually implement it via physical code.
        }
    }
}
