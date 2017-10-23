using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tusimaka.Controllers;
using Tusimaka.BLL;
using Tusimaka.DAL;
using Tusimaka.Model;
using System.Web;
using System.Web.Mvc;//using Session.MockUnitTest.Controllers;
using MvcContrib.TestHelper;

namespace Tusimaka.Enhetstest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void LoggInn()
        {
            // Arrange
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            // Act
            var resultat = (ViewResult)controller.LoggInn();
            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }
        [TestMethod]
        public void LoggInnOK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController();
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            // Act
            var result = (ViewResult)controller.AdminStart();
            // Assert
            Assert.AreEqual(true, result.ViewName);
        }
    }
}
