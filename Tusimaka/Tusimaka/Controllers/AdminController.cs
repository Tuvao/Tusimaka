using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tusimaka.BLL;
using Tusimaka.Model;

namespace Tusimaka.Controllers
{
    public class AdminController : Controller
    {
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

            if (BrukerIDB(innAdminBruker))
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
        //public ActionResult KundeAdministrer()
        //{
        //    var db = new DBContext())
        //    {
        //        List<Model.Kunder> alleKunder = db.Kunder.ToList();
        //        return View(alleKunder);
        //    }
        //}
    }
}