using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tusimaka.Controllers;
using Tusimaka.BLL;
using Tusimaka.DAL;
using Tusimaka.Model;
using SessionMockUnitTest.Controllers;
using MvcContrib.TestHelper;

namespace Enhetstest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void RegistrerKunde()
        {
        //    //denne tester kun på en metode som kun returnerer et view
        //    // Arrange
        //    var controller = new AdminController(new AdminLogikk(new AdminRepositoryStub()));
        //    // Act
        //    var resultat = (ViewResult)controller.RegistrerKunde();
        //    // Assert
        //    Assert.AreEqual(resultat.ViewName, "");


        }
        [TestMethod]
        public void LoggInn()
        {
            //Arrange
            var SessionMock = new TestControllerBuilder();
        }
        //[TestMethod]
        //public void LoggInn()
        //{
        //    // Arrange
        //    var SessionMock = new TestControllerBuilder();
        //    var controller = new AdminController();
        //    SessionMock.InitializeController(controller);
        //    // setningen under må være etter InitializeController
        //    controller.Session["LoggetInn"] = true;
        //    // Act
        //    var result = (ViewResult)controller.Index();
        //    // Assert
        //    Assert.AreEqual("", result.ViewName);
        //}
    }
}
