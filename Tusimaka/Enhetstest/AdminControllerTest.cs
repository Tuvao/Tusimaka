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
            Assert.AreEqual(result.RouteValues.Values.First(), "AdminStart");
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
            Assert.AreEqual(result.ViewName, "");
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
        public void AdminStart_False_Session()
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
        [TestMethod]
        public void List_alle_flyruter_False_Session()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminFlyruterBLL(new AdminFlyruterDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = false;
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
            Assert.AreEqual(actionResult.ViewName, "LoggInn");

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
        [TestMethod]
        public void Registrer_Flyruter_Post_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminFlyruterBLL(new AdminFlyruterDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var innFlyrute = new Strekning()
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
            // Act
            var result = (RedirectToRouteResult)controller.RegistrerFlyrute(innFlyrute);
            // Assert
            Assert.AreEqual(result.RouteValues.Values.First(), "FlyruterAdministrer");
        }
        [TestMethod]
        public void EndreKunde_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var innKunde = new Kunde()
            {
                Fornavn = "Maria",
                Etternavn = "Berg",
                Epost = "epost@epost.no",
                Kjonn = "Kvinne"
            };
            // Act
            var resultat = (RedirectToRouteResult)controller.EndreKunde(1, innKunde);

            // Assert
            Assert.AreEqual(resultat.RouteValues.Values.First(), "KundeAdministrer");
        }
        [TestMethod]
        public void EndreKunde_feil_validering_ModelState()
        {
            // Arrange
            var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));
            var innKunde = new Kunde();
            controller.ViewData.ModelState.AddModelError("feil", "KundeID = 0");

            // Act
            var actionResult = (ViewResult)controller.EndreKunde(0, innKunde);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "KundeID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void SlettKunde()
        {
            // Arrange
            var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.slettKunde(1);
            var resultat = (Kunde)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void SlettKunde_Ok()
        {
            // Arrange
            var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));
            var innKunde = new Kunde()
            {
                Fornavn = "Tuva",
                Etternavn = "Olsen",
                Epost = "epost@epost.no",
                Kjonn = "Kvinne"
            };

            // Act
            var actionResult = (RedirectToRouteResult)controller.slettKunde(1, innKunde);

            // Assert
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "KundeAdministrer");

        }

        [TestMethod]
        public void SlettKunde_IkkeOk()
        {
            // Arrange
            var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));
            var innKunde = new Kunde()
            {
                Fornavn = "Tuva",
                Etternavn = "Olsen",
                Epost = "epost@epost.no",
                Kjonn = "Kvinne"
            };

            // Act
            var actionResult = (ViewResult)controller.slettKunde(0, innKunde);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
    }

}
