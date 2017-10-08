using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Tusimaka.Models;
using static Tusimaka.Models.DBContext;

namespace Tusimaka.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Bestill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Bestill(FlyBestillinger innFlyInfo)
        {
            //Dataene fra Bestill legges i Sessions helt til vi får kundeID og kan legge dataene i DB
            //Session["bestillingsInfo"] = new List<Models.FlyBestillinger>();
            //var bestillinger = (List<Models.FlyBestillinger>)Session["bestillingsInfo"];
            //bestillinger.Add(innFlyInfo);
            //Session["bestillingsInfo"] = bestillinger;
            var db = new DB();
            bool OK = db.lagreFlyBestilling(innFlyInfo);
            if (OK)
            {
                return RedirectToAction("KundeRegistrering");
            }
            else
            {
                return View();
            }
        }
        
        public ActionResult KundeRegistrering()
        {
            //Dataene fra Bestill viewet må ligge i en session og vises i KundeReg viewet 
            //for å vise rett antall passasjerer. 
            return View();
        }


        [HttpPost]
        public ActionResult KundeRegistrering(Kunde innKunde)
        {
            //var bestillinger = Session["bestillingsinfo"];
            //var bestilling = (Models.FlyBestillinger)Session["bestillingsinfo"];
            //var bestillinger = (List<Models.FlyBestillinger>)Session["bestillingsInfo"];
            //Session["bestillingsInfo"] = bestillinger;
            var db = new DB();
            bool OK = db.lagreKunde(innKunde);
            if (OK)
            {
               return RedirectToAction("RegistrerBetaling");
            }
            else
            {
                return View();
            }
           
        }

        public ActionResult RegistrerBetaling()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult RegistrerBetaling(Models.BetalingsInformasjon innBetaling, Models.FlyBestillingKunde flyBestilling)
        {
            var db = new DB();
            bool OK2 = db.lagreKundeIdMotFlyBestilling();
            if (OK2)
            {
                var db2 = new DB();
                bool OK3 = db2.lagreBetalingsinformasjon(innBetaling);
                if(OK3)
                {
                    return RedirectToAction("Bekreftelse");
                }
                
                
            }
            return View();
            
        }

        public ActionResult Bekreftelse()
        {
            //var bestillinger = (List<Models.FlyBestillinger>)Session["bestillingsInfo"];
            //var betaling = (List<Models.BetalingsInformasjon>)Session["betalingsinfo"];

            //Lister ut kunder
            var db = new DB();
            Kunder hentEnKunde = db.hentEnKunde();
            return View(hentEnKunde);
        }

        public string hentAlleFraFlyplasser()
        {
            using (var db = new DBContext())
            {
                List<strekning> alleFly = db.Strekning.ToList();

                var alleFraFly = new List<string>();
                
                foreach (strekning f in alleFly)
                {
                    string funnetStrekning = alleFraFly.FirstOrDefault(fl => fl.Contains(f.fraFlyplass));
                    if (funnetStrekning == null)
                    {
                        // ikke funnet strekning i listen, legg den inn i listen
                        alleFraFly.Add(f.fraFlyplass);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleFraFly);
            }
        }

        public string hentTilFlyplasser(string fraFlyPlass)
        {
            using (var db = new DBContext())
            {
                List<strekning> alleFly = db.Strekning.ToList();

                var alleTilFly = new List<string>();

                foreach (strekning f in alleFly)
                {
                    if (f.fraFlyplass == fraFlyPlass)
                    {
                        string funnetStrekning = alleTilFly.FirstOrDefault(fl => fl.Contains(f.tilFlyplass));
                        if (funnetStrekning == null)
                        {
                            // ikke funnet strekning i listen, legg den inn i listen
                            alleTilFly.Add(f.tilFlyplass);
                        }
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleTilFly);
            }
        }
        public string hentStrekning(string fraFlyplass, string tilFlyPlass, string dato, int antallLedigeSeter)
        {
            using (var db = new DBContext())
            {
                List<strekning> alleFly = db.Strekning.Where(
                    f => f.tilFlyplass == tilFlyPlass && f.fraFlyplass == fraFlyplass && f.dato == dato && f.antallLedigeSeter >= antallLedigeSeter).ToList();

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleFly);
            }
        }
        public string hentBestilling()
        {
            using (var db = new DBContext())
            {
                int flyBestillingsId = db.FlyBestilling.Max(f => f.flyBestillingsID);
                Models.FlyBestilling finnStrekning = db.FlyBestilling.FirstOrDefault(f => f.flyBestillingsID == flyBestillingsId);
                int strekningsId = finnStrekning.StrekningsID;
                Models.strekning finnStrekningList = db.Strekning.FirstOrDefault(s => s.StrekningsID == strekningsId);

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(finnStrekningList);
            }
        }
        public string hentRetur()
        {
            using (var db = new DBContext())
            {
                int flyBestillingsId = db.FlyBestilling.Max(f => f.flyBestillingsID);
                Models.FlyBestilling finnRetur = db.FlyBestilling.FirstOrDefault(f => f.flyBestillingsID == flyBestillingsId);
                Models.strekning finnReturList = new Models.strekning();
                if (finnRetur.returID != null){
                    int? returId = finnRetur.returID;
                    finnReturList = db.Strekning.FirstOrDefault(r => r.StrekningsID == returId );
                }

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(finnReturList);
            }
        }
        public string hentReferanseNR()
        {
            using (var db = new DBContext())
            {
                int flyBestillingsId = db.FlyBestilling.Max(f => f.flyBestillingsID);
                Models.FlyBestilling finnRefNr = db.FlyBestilling.FirstOrDefault(f => f.flyBestillingsID == flyBestillingsId);

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(finnRefNr);
            }
        }
    }
}