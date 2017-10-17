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
        // GET: Admin
        //Index går til admin start viewet
        public ActionResult Index()
        {
            return View();
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