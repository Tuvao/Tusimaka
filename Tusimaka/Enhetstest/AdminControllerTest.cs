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
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            SessionMock.InitializeController(controller);
            var session = controller.Session["LoggetInn"] = true;
            var innAdminBruker = new AdminBruker()
            {
                Brukernavn = "Brukernavn",
                Passord = "Passord"
            };
            // Act
            var result = (RedirectToRouteResult)controller.LoggInn(innAdminBruker);
            // Assert
            Assert.AreEqual(result.RouteValues.Values.First(), "AdminStart");
            Assert.AreEqual(session, true);
        }
        [TestMethod]
        public void LoggInn_IkkeOK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            SessionMock.InitializeController(controller);
            var session = controller.Session["LoggetInn"] = false;
            var innAdminBruker = new AdminBruker()
            {
                Brukernavn = "",
                Passord = ""
            };
            // Act
            var result = (ViewResult)controller.LoggInn(innAdminBruker);
            Assert.AreEqual(result.ViewName, "");
            Assert.AreEqual(session,false);
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
        public void List_alle_Flyruter_OK()
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
        public void List_alle_Kunder_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var forventetResultat = new List<Kunde>();
            var kunde = new Kunde()
            {
                KundeID = 1,
                Fornavn = "Helene",
                Etternavn = "Andersen",
                Epost = "helene@andersen.no",
                Kjonn = "Kvinne"

            };

            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);
            // Act
            var actionResult = (ViewResult)controller.KundeAdministrer();
            var resultat = (List<Kunde>)actionResult.Model;
            // Assert
            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].KundeID, resultat[i].KundeID);
                Assert.AreEqual(forventetResultat[i].Fornavn, resultat[i].Fornavn);
                Assert.AreEqual(forventetResultat[i].Etternavn, resultat[i].Etternavn);
                Assert.AreEqual(forventetResultat[i].Epost, resultat[i].Epost);
                Assert.AreEqual(forventetResultat[i].Kjonn, resultat[i].Kjonn);
            }
        }
        [TestMethod]
        public void EndreKunde()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;

            // Act
            var resultat = (ViewResult)controller.EndreKunde(1);
            // Assert
            Assert.AreEqual(resultat.ViewName, "");
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
        public void EndreKunde_feil_DB()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var innKunde = new Kunde();
            innKunde.Fornavn = "";
           
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
        public void RegistrerKunde()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new KundeBLL(new KundeRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;

            // Act
            var actionResult = (ViewResult)controller.RegistrerKunde();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void RegistrerKunde_feil_DB()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new KundeBLL(new KundeRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var innKunde = new Kunde();
            innKunde.Fornavn = "";

            // Act
            var actionResult = (ViewResult)controller.RegistrerKunde(innKunde);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerKunde_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new KundeBLL(new KundeRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var innKunde = new Kunde()
            {
                Fornavn = "Petra",
                Etternavn = "Olsen",
                Epost = "test@test.no",
                Kjonn = "Kvinne"
            };
            // Act
            var result = (RedirectToRouteResult)controller.RegistrerKunde(innKunde);

            // Assert
            Assert.AreEqual(result.RouteValues.Values.First(), "KundeAdministrer");
        }
        [TestMethod]
        public void RegistrerFlyrute()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new KundeBLL(new KundeRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;

            // Act
            var actionResult = (ViewResult)controller.RegistrerFlyrute();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void RegistrerFlyrute_OK()
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
        public void RegistrerFlyrute_feil_DB()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminFlyruterBLL(new AdminFlyruterDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            controller.Session["LoggetInn"] = true;
            var innFlyrute = new Strekning();
            innFlyrute.FraFlyplass = "";

            // Act
            var actionResult = (ViewResult)controller.RegistrerFlyrute(innFlyrute);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void EndreFlyrute()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminFlyruterBLL(new AdminFlyruterDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;

            // Act
            var resultat = (ViewResult)controller.EndreFlyrute(1);
            // Assert
            Assert.AreEqual(resultat.ViewName, "");
        }

        [TestMethod]
        public void EndreFlyrute_OK()
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
            var result = (RedirectToRouteResult)controller.EndreFlyrute(1, innFlyrute);
            // Assert
            Assert.AreEqual(result.RouteValues.Values.First(), "FlyruterAdministrer");

        }

        [TestMethod]
        public void EndreFlyrute_feil_DB()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminFlyruterBLL(new AdminFlyruterDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var innFlyrute = new Strekning();
             innFlyrute.FraFlyplass = "";


            //act
            var actionResult = (ViewResult)controller.EndreFlyrute(0, innFlyrute);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }

        [TestMethod]
        public void EndreFlyrute_feil_validering_ModelState()
        {
            // Arrange
            var controller = new AdminController(new AdminFlyruterBLL(new AdminFlyruterDALRepositoryStub()));
            var innFlyrute = new Strekning();
            controller.ViewData.ModelState.AddModelError("feil", "StrekningsID = 0");

            // Act
            var actionResult = (ViewResult)controller.EndreFlyrute(0, innFlyrute);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "StrekningsID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void NyKundeBestilling()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminBestillingBLL(new AdminBestillingDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;

            // Act
            var actionResult = (ViewResult)controller.NyKundeBestilling();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void NyKundeBestilling_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminBestillingBLL(new AdminBestillingDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var nyBestilling = new FlyBestillinger();
            nyBestilling.FlyBestillingsID = 1; 
            // Act
            var result = (RedirectToRouteResult)controller.NyKundeBestilling(1, nyBestilling);

            // Assert
            Assert.AreEqual(result.RouteValues.Values.First(), "KundeAdministrer");
        }
        [TestMethod]
        public void NyKundeBestilling_feil_DB()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminBestillingBLL(new AdminBestillingDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var nyBestilling = new FlyBestillinger();
            nyBestilling.FlyBestillingsID = 0;
            // Act
            var result = (ViewResult)controller.NyKundeBestilling(0, nyBestilling);

            // Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void List_alle_KundeBestillinger_OK()
        {
            // Arrange
            var SessionMock = new TestControllerBuilder();
            var controller = new AdminController(new AdminBestillingBLL(new AdminBestillingDALRepositoryStub()));
            SessionMock.InitializeController(controller);
            // setningen under må være etter InitializeController
            controller.Session["LoggetInn"] = true;
            var skrivUtKundeBestilling = new List<KundeBestillinger>();
            var bestilling = new KundeBestillinger
            {
                KundeID = 1,
                Fornavn = "Helene",
                Etternavn = "Andersen",
                StrekningsID = 1,
                FraFlyplass = "Oslo",
                TilFlyplass = "Bergen",
                Dato = "2017-10-20",
                Pris = 1234,
                Tid = "12:30",
                AntallPersoner = 4

            };

            skrivUtKundeBestilling.Add(bestilling);
            skrivUtKundeBestilling.Add(bestilling);
            skrivUtKundeBestilling.Add(bestilling);
            // Act
            var actionResult = (ViewResult)controller.KundeBestillinger(1);
            var resultat = (List<KundeBestillinger>)actionResult.Model;
            // Assert
            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(skrivUtKundeBestilling[i].KundeID, resultat[i].KundeID);
                Assert.AreEqual(skrivUtKundeBestilling[i].Fornavn, resultat[i].Fornavn);
                Assert.AreEqual(skrivUtKundeBestilling[i].Etternavn, resultat[i].Etternavn);
                Assert.AreEqual(skrivUtKundeBestilling[i].StrekningsID, resultat[i].StrekningsID);
                Assert.AreEqual(skrivUtKundeBestilling[i].FraFlyplass, resultat[i].FraFlyplass);
                Assert.AreEqual(skrivUtKundeBestilling[i].TilFlyplass, resultat[i].TilFlyplass);
                Assert.AreEqual(skrivUtKundeBestilling[i].Dato, resultat[i].Dato);
                Assert.AreEqual(skrivUtKundeBestilling[i].Pris, resultat[i].Pris);
                Assert.AreEqual(skrivUtKundeBestilling[i].Tid, resultat[i].Tid);
                Assert.AreEqual(skrivUtKundeBestilling[i].AntallPersoner, resultat[i].AntallPersoner);
            }

        }
    }
}

//    [TestMethod]
//    public void SlettKunde()
//    {
//        // Arrange
//        var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));

//        // Act
//        var actionResult = (ViewResult)controller.slettKunde(1);
//        var resultat = (Kunde)actionResult.Model;

//        // Assert
//        Assert.AreEqual(actionResult.ViewName, "");
//    }

        //[TestMethod]
        //public void SlettKunde_Ok()
        //{
        //    // Arrange
        //    var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));
        //    var innKunde = new Kunde()
        //    {
        //        Fornavn = "Tuva",
        //        Etternavn = "Olsen",
        //        Epost = "epost@epost.no",
        //        Kjonn = "Kvinne"
        //    };

        //    // Act
        //    var actionResult = (bool)controller.slettKunde(1);

        //    // Assert
        //    Assert.AreEqual(actionResult.RouteName, "");
        //    Assert.IsTrue(actionResult);
        //}

//    [TestMethod]
//    public void SlettKunde_IkkeOk()
//    {
//        // Arrange
//        var controller = new AdminController(new AdminKundeBLL(new AdminKundeDALRepositoryStub()));
//        var innKunde = new Kunde()
//        {
//            Fornavn = "Tuva",
//            Etternavn = "Olsen",
//            Epost = "epost@epost.no",
//            Kjonn = "Kvinne"
//        };

//        // Act
//        var actionResult = (ViewResult)controller.slettKunde(0, innKunde);

//        // Assert
//        Assert.AreEqual(actionResult.ViewName, "");
//    }



