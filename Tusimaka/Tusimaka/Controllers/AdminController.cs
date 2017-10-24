using System;
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
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult LoggInn()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult LoggInn(AdminBruker innAdminBruker)
        {
            var adminBLL = new AdminBLL();
            bool ok = adminBLL.Bruker_i_DB(innAdminBruker);
            if (ok)
            {
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return RedirectToAction("AdminStart");
            }
            else
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }

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
                    var db = new AdminFlyruterBLL();
                    List<Strekning> alleFlyruter = db.hentAlleFlyruter();
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
                    var db = new AdminKundeBLL();
                    List<Kunde> alleKunder = db.hentAlleKunder();
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
            if (ModelState.IsValid)
            {
                var db = new AdminFlyruterBLL();
                bool OK = db.lagreFlyrute(innFlyrute);
                if (OK)
                {
                    return RedirectToAction("FlyruterAdministrer");
                }
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
            if (ModelState.IsValid)
            {
                var db = new KundeBLL();
                bool OK = db.lagreKunde(innKunde);
                if (OK)
                {
                    return RedirectToAction("KundeAdministrer");
                }
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
                    var adminKundeBLL = new AdminKundeBLL();
                    Kunde hentSpesifikKunde = adminKundeBLL.hentDenneKunden(id);
                    return View(hentSpesifikKunde);
                }
            }
            return RedirectToAction("LoggInn");
        }

        [HttpPost]
        public ActionResult EndreKunde(int id, Kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                var adminKundeBLL = new AdminKundeBLL();
                bool endreOK = adminKundeBLL.endreKunde(id, innKunde);
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
                    var adminBestillingBLL = new AdminBestillingBLL();
                    List<KundeBestillinger> hentKundesFlyruter = adminBestillingBLL.hentKundesFlyBestillinger(id);
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
                    var adminFlyruteBLL = new AdminFlyruterBLL();
                    Strekning hentSpesifikFlyrute = adminFlyruteBLL.hentDenneFlyruten(id);
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
                var adminFlyruterBLL = new AdminFlyruterBLL();
                bool endreOK = adminFlyruterBLL.endreFlyrute(id, innFlyrute);
                if (endreOK)
                {
                    return RedirectToAction("FlyruterAdministrer");
                }
            }
            return View();
        }

        public ActionResult NyKundeBestilling(int id)
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
            if (ModelState.IsValid)
            {
                var adminBestillBLL = new AdminBestillingBLL();
                bool nyBestillingOK = adminBestillBLL.LagreAdminFlyBestilling(id, nyBestilling);
                if (nyBestillingOK)
                {
                    return RedirectToAction("KundeAdministrer");
                }
            }
            return View();
        }

        public void SlettBestilling(int id)
        {
            var adminBestillBLL = new AdminBestillingBLL();
            try
            {
                bool slettOK = adminBestillBLL.SlettKundeBestilling(id);
            }
            catch(Exception feil)
            {
                //logging til db
            }
        }

        public void slettKunde(int id)
        {
            var adminKundeBLL = new AdminKundeBLL();
            try
            {
                bool slettOK = adminKundeBLL.slettKunde(id);
            }
            catch (Exception feil)
            {
                //logging til db
            }
        }

        public void slettFlyrute(int id)
        {
            var adminFlyruteBLL = new AdminFlyruterBLL();
            try
            {
                bool slettOK = adminFlyruteBLL.slettFlyrute(id);
            }
            catch (Exception feil)
            {
                //logging til db
            }
        }

    }
}