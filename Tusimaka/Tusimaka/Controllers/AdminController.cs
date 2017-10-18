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
            var ok = new AdminBLL();
            if (ok.Bruker_i_DB(innAdminBruker))
            {
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return View();
            }
            else
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }

        }
        public ActionResult KundeAdministrer()
        {
            var db = new KundeBLL();
            List<Kunde> alleKunder = db.hentAlleKunder();
            return View(alleKunder);
        }
    }
}