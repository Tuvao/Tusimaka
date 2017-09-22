using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tusimaka.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
  
        public ActionResult Bestill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bestilling(Models.Bestilling innBestilling)
        {
            //Connection til DB
            using (var db = new Models.DB())
            {
                try
                {
                    db.Bestillinger.Add(innBestilling);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    //hva skjer om feil -- 
                }
            }
            return RedirectToAction("Index");
        }
    }
}