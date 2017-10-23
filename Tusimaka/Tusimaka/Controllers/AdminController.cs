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

        public AdminController(IKundeLogikk kundeStub, IAdminBestillingLogikk adminBestillStub, IAdminFlyruterLogikk adminFlyruterStub, IAdminKundeLogikk adminKundeStub, IAdminLogikk adminStub)
        {
            _kundeBLL = kundeStub;
            _adminBestillBLL = adminBestillStub;
            _adminFlyruterBLL = adminFlyruterStub;
            _adminKundeBLL = adminKundeStub;
            _adminBLL = adminStub;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoggInn()
        {
            if(Session["LoggetInn"] == null)
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
            bool ok = _adminBLL.Bruker_I_DB(innAdminBruker);
            if (ok)
            {
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                //return View();
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
            //Legg til if session[LoggetInn"] == true
            return View();
        }

        public ActionResult FlyruterAdministrer()
        {
            var db = new AdminFlyruterBLL();
            List<Strekning> alleFlyruter = db.hentAlleFlyruter();
            return View(alleFlyruter);
        }

        public ActionResult KundeAdministrer()
        {
            var db = new AdminKundeBLL();
            List<Kunde> alleKunder = db.hentAlleKunder();
            return View(alleKunder);
        }

        public ActionResult RegistrerFlyrute()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerFlyrute(Strekning innFlyrute)
        {
            var db = new AdminFlyruterBLL();
            bool OK = db.lagreFlyrute(innFlyrute);
            if (OK)
            {
                return RedirectToAction("FlyruterAdministrer");
            }
            else
            {
                return View();
            }
        }

        public ActionResult RegistrerKunde()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerKunde(Kunde innKunde)
        {
            var db = new KundeBLL();
            bool OK = db.lagreKunde(innKunde);
            if (OK)
            {
                return RedirectToAction("KundeAdministrer");
            }
            else
            {
                return View();
            }
        }
        public ActionResult EndreKunde(int id)
        {
            var adminKundeBLL = new AdminKundeBLL();
            Kunde hentSpesifikKunde = adminKundeBLL.hentDenneKunden(id);
            return View(hentSpesifikKunde);
        }

        [HttpPost]
        public ActionResult EndreKunde(int id, Kunde innKunde)
        {
            var adminKundeBLL = new AdminKundeBLL();
            bool endreOK = adminKundeBLL.endreKunde(id, innKunde);
            return RedirectToAction("KundeAdministrer");
        }

        public ActionResult KundeBestillinger(int id)
        {
            var adminBestillingBLL = new AdminBestillingBLL();
            List<KundeBestillinger> hentKundesFlyruter = adminBestillingBLL.hentKundesFlyBestillinger(id);
            return View(hentKundesFlyruter);
        }

        public ActionResult EndreFlyrute(int id)
        {
            var adminFlyruteBLL = new AdminFlyruterBLL();
            Strekning hentSpesifikFlyrute = adminFlyruteBLL.hentDenneFlyruten(id);
            return View(hentSpesifikFlyrute);
        }
        
        [HttpPost]
        public ActionResult EndreFlyrute(int id, Strekning innFlyrute)
        {
            var adminFlyruterBLL = new AdminFlyruterBLL();
            bool endreOK = adminFlyruterBLL.endreFlyrute(id, innFlyrute);
            return RedirectToAction("FlyruterAdministrer");
        }

        public ActionResult NyKundeBestilling(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult NyKundeBestilling(int id, FlyBestillinger nyBestilling)
        {
            var adminBestillBLL = new AdminBestillingBLL();
            bool nyBestillingOK = adminBestillBLL.LagreAdminFlyBestilling(id, nyBestilling);
            return RedirectToAction("KundeAdministrer");
        }

        public void SlettBestilling(int id)
        {
            var adminBestillBLL = new AdminBestillingBLL();
            bool slettOK = adminBestillBLL.SlettKundeBestilling(id);
        }

        public void slettKunde(int id)
        {
            var adminKundeBLL = new AdminKundeBLL();
            bool slettOK = adminKundeBLL.slettKunde(id);
        }

        public void slettFlyrute(int id)
        {
            var adminFlyruteBLL = new AdminFlyruterBLL();
            bool slettOK = adminFlyruteBLL.slettFlyrute(id);
        }

    }
}