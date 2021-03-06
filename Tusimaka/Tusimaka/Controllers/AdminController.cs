﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tusimaka.Model;
using Tusimaka.BLL;

namespace Tusimaka.Controllers
{
    public class AdminController : Controller
    {
        private IKundeLogikk _kundeBLL;
        private IAdminBestillingLogikk _adminBestillBLL;
        private IAdminLogikk _adminBLL;
        private IAdminFlyruterLogikk _adminFlyruterBLL;
        private IAdminKundeLogikk _adminKundeBLL;

        public AdminController()
        {
            _kundeBLL = new KundeBLL();
            _adminBestillBLL = new AdminBestillingBLL();
            _adminFlyruterBLL = new AdminFlyruterBLL();
            _adminKundeBLL = new AdminKundeBLL();
            _adminBLL = new AdminBLL();
        }

        public AdminController(IKundeLogikk stub)
        {
            _kundeBLL = stub;
        }
        public AdminController(IAdminBestillingLogikk stub)
        {
            _adminBestillBLL = stub;
        }
        public AdminController(IAdminFlyruterLogikk stub)
        {
            _adminFlyruterBLL = stub;
        }
        public AdminController(IAdminKundeLogikk stub)
        {
            _adminKundeBLL = stub;
        }

        public AdminController(IAdminLogikk stub)
        {
            _adminBLL = stub;
        }

        public ActionResult LoggInn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoggInn(AdminBruker innAdminBruker)
        {
            if(ModelState.IsValid)
            {
                bool ok = _adminBLL.Bruker_i_DB(innAdminBruker);
                if (ok)
                {
                    Session["LoggetInn"] = true;
                    ViewBag.Innlogget = true;
                    return RedirectToAction("AdminStart");
                }
            }
            Session["LoggetInn"] = false;
            ViewBag.Innlogget = false;
            return View();
        }
        public ActionResult AdminStart()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("LoggInn");
        }
            
        public ActionResult FlyruterAdministrer()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    List<Strekning> alleFlyruter = _adminFlyruterBLL.hentAlleFlyruter();
                    return View(alleFlyruter);
                }
            }
            return RedirectToAction("LoggInn");
        }

        public ActionResult KundeAdministrer()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    List<Kunde> alleKunder = _adminKundeBLL.hentAlleKunder();
                    return View(alleKunder);
                }
            }
            return RedirectToAction("LoggInn");

        }

        public ActionResult RegistrerFlyrute()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("LoggInn");
        }

        [HttpPost]
        public ActionResult RegistrerFlyrute(Strekning innFlyrute)
        {
            bool OK = _adminFlyruterBLL.lagreFlyrute(innFlyrute);
            if (OK)
            {
                return RedirectToAction("FlyruterAdministrer");
            }
            return View();
        }

        public ActionResult RegistrerKunde()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("LoggInn");
        }

        [HttpPost]
        public ActionResult RegistrerKunde(Kunde innKunde)
        {
            bool OK = _kundeBLL.lagreKunde(innKunde);
            if (OK)
            {
                return RedirectToAction("KundeAdministrer");
            }
            return View();
        }
        public ActionResult EndreKunde(int id)
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    Kunde hentSpesifikKunde = _adminKundeBLL.hentDenneKunden(id);
                    return View(hentSpesifikKunde);
                }
            }
            return RedirectToAction("LoggInn");
        }

        [HttpPost]
        public ActionResult EndreKunde(int id, Kunde innKunde)
        {
            if(ModelState.IsValid)
            {
                bool endreOK = _adminKundeBLL.endreKunde(id, innKunde);
                if (endreOK)
                {
                    return RedirectToAction("KundeAdministrer");
                }
            }
            return View();
        }

        public ActionResult KundeBestillinger(int id)
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    List<KundeBestillinger> hentKundesFlyruter = _adminBestillBLL.hentKundesFlyBestillinger(id);
                    Session["KundeID"] = id;
                    return View(hentKundesFlyruter);
                }
            }
            return RedirectToAction("LoggInn");
        }

        public ActionResult EndreFlyrute(int id)
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    Strekning hentSpesifikFlyrute = _adminFlyruterBLL.hentDenneFlyruten(id);
                    return View(hentSpesifikFlyrute);
                }
            }
            return RedirectToAction("LoggInn");
        }
        
        [HttpPost]
        public ActionResult EndreFlyrute(int id, Strekning innFlyrute)
        {
            if (ModelState.IsValid)
            {
                bool endreOK = _adminFlyruterBLL.endreFlyrute(id, innFlyrute);
                if (endreOK)
                {
                    return RedirectToAction("FlyruterAdministrer");
                }
            }
            return View();
        }

        public ActionResult NyKundeBestilling()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("LoggInn");
        }
        [HttpPost]
        public ActionResult NyKundeBestilling(int id, FlyBestillinger nyBestilling)
        {
            bool nyBestillingOK = _adminBestillBLL.LagreAdminFlyBestilling(id, nyBestilling);
            if (nyBestillingOK)
            {
                //lagrer id som session for å kunne koble betaling og flybestilling
                Session["id1"] = id;
                return RedirectToAction("AdminBetalingNyBestilling");
            }
            return View();
        }
        public ActionResult AdminBetalingNyBestilling()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("LoggInn");
        }
        [HttpPost]
        public ActionResult AdminBetalingNyBestilling(BetalingsInformasjon nyBetaling)
        {
            if (Session["id1"] != null)
            {
                //session id er flybestillingsid lagret fra forrige view. 
                int id1 = (int)Session["id1"];
                bool nyBetalingOK = _adminBestillBLL.lagreBetalingsinformasjon(id1, nyBetaling);
                if (nyBetalingOK)
                {
                    return RedirectToAction("KundeAdministrer");
                }
            }
            if (Session["id1"] == null)
            {
                //hvis det skjer noe "rart" med id session.
                TempData["error"] = "<script>alert('Det har skjedd en feil, betalingen gikk ikke igjennom. Bestillingen må slettes i og utføres på nytt.');</script>";
                return RedirectToAction("KundeAdministrer");
            }
            //f.eks. hvis selve betalingen ikke går igjennom. 
            //da lurt med en feilmelding, som f.eks. TempDate i if'en ovenfor.  
            return RedirectToAction("AdminStart");
        }
        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = false;
            bool loggetinn = (bool)Session["LoggetInn"];
            if (loggetinn)
            {
                return View();
            }
            return RedirectToAction("LoggInn");
        }

        public bool SlettBestilling(int id)
        {
            try
            {
                bool slettOK = _adminBestillBLL.SlettKundeBestilling(id);
            }
            catch(Exception feil)
            {
                //logging til db skjer direkte i DAL
            }
            return true;
        }

        public bool slettKunde(int id)
        {
            try
            {
                bool slettOK = _adminKundeBLL.slettKunde(id);
                
            }
            catch (Exception feil)
            {
                //logging til db skjer direkte i DAL
            }
            return true;
        }

        public bool slettFlyrute(int id)
        {
            try
            {
                bool slettOK = _adminFlyruterBLL.slettFlyrute(id);
            }
            catch (Exception feil)
            {
                //logging til db skjer direkte i DAL
            }
            return true;
        }

    }
}