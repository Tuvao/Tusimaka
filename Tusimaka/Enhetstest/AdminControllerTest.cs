using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tusimaka.Controllers;
using Tusimaka.BLL;
using Tusimaka.DAL;
using Tusimaka.Model;
using System.Web;
using System.Web.Mvc;
//using Session.MockUnitTest.Controllers;
using MvcContrib.TestHelper;
using System.Linq;

namespace Tusimaka.Enhetstest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void LoggInn()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController();
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = false;
            // Act
            var result = (ViewResult)controller.LoggInn();
            // Assert
            Assert.AreEqual("", result.ViewName);
        }
        [TestMethod]
        public void AdminStart()
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
            Assert.AreEqual("", result.ViewName);
        }
        [TestMethod]
        public void AdminStart_IkkeOK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController();
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = false;
            // Act
            var result = (RedirectToRouteResult)controller.AdminStart();
            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "LoggInn");
        }

        [TestMethod]
        public void LoggInn_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController();
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            // Act
            var result = (RedirectToRouteResult)controller.LoggInn();
            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "AdminStart");
        }
    }
}
