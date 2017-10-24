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
using System.Collections.Generic;

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
            //var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            //SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            //controller.Session["LoggetInn"] = true;
            var innAdminBruker = new AdminBruker()
            {
                Brukernavn = "Brukernavn",
                Passord = "Passord"
            };
            // Act
            var result = (RedirectToRouteResult)controller.LoggInn(innAdminBruker);
            // Assert
            //Assert.AreEqual(result.RouteName, "Admin");
            Assert.AreEqual(result.RouteValues.Values.First(), "AdminStart");
            //Assert.AreEqual("AdminStart", result.RouteValues["action"]);
        }
        [TestMethod]
        public void LoggInn_IkkeOK()
        {
            // Arrange
            //var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            //SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            //controller.Session["LoggetInn"] = true;
            var innAdminBruker = new AdminBruker()
            {
                Brukernavn = "",
                Passord = ""
            };
            // Act
            var result = (ViewResult)controller.LoggInn(innAdminBruker);
            Assert.AreEqual("", result.ViewName);
        }
        [TestMethod]
        public void List_alle_flyruter_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminFlyruterBLL(new AdminFlyruterDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var forventetResultat = new List<Strekning>();
            var flyrute = new Strekning()
            {
                StrekningsID = 1,
                FraFlyplass = "Bergen",
                TilFlyplass = "Oslo",
                Dato = "2017-10-20",
                Tid = "12:30",
                Pris = 1234,
                FlyTid = 45,
                AntallLedigeSeter = 4
            };
            forventetResultat.Add(flyrute);
            forventetResultat.Add(flyrute);
            forventetResultat.Add(flyrute);
            // Act
            var actionResult = (ViewResult)controller.FlyruterAdministrer();
            var resultat = (List<Strekning>)actionResult.Model;
            // Assert
            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].StrekningsID, resultat[i].StrekningsID);
                Assert.AreEqual(forventetResultat[i].FraFlyplass, resultat[i].FraFlyplass);
                Assert.AreEqual(forventetResultat[i].TilFlyplass, resultat[i].TilFlyplass);
                Assert.AreEqual(forventetResultat[i].Dato, resultat[i].Dato);
                Assert.AreEqual(forventetResultat[i].Tid, resultat[i].Tid);
                Assert.AreEqual(forventetResultat[i].Pris, resultat[i].Pris);
                Assert.AreEqual(forventetResultat[i].FlyTid, resultat[i].FlyTid);
                Assert.AreEqual(forventetResultat[i].AntallLedigeSeter, resultat[i].AntallLedigeSeter);
            }
        }
    }
}
