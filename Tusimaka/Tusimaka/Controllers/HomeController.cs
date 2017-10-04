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
            Session["bestillingsInfo"] = new List<Models.FlyBestillinger>();
            return View();
        }
        [HttpPost]
        public ActionResult Bestill(Models.FlyBestillinger innFlyInfo)
        {
            List<Models.FlyBestillinger> bestillinger = (List<Models.FlyBestillinger>)Session["bestillingsInfo"];
            bestillinger.Add(innFlyInfo);
            Session["bestillingsInfo"] = bestillinger;
            return RedirectToAction("KundeRegistrering");
        }
        public ActionResult KundeRegistrering()
        {
            var bestillinger = (List<Models.FlyBestillinger>)Session["bestillingsInfo"];
            return View(bestillinger);
        }



        public ActionResult Betaling()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KundeRegistrering(Models.Kunde innKunde)
        {
            using (var db = new Models.DBContext())
            {
                try
                {
                    db.Kunder.Add(innKunde);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    // her bør det komme noe mer
                }
            }
            return RedirectToAction("Liste");
        }

        //public ActionResult KundeRegistrering()
        //{





        //using (var db = new DBContext())
        //{
        //    //her må vi også få med strekningsid
        //    //vi har jo ikke lagret noe i databasen enda, så er usikker på hvordan vi skal få det fram?

        //    //var fra = Request.Form["drop1"];
        //    //Session["drop1"] = fra;

        //    //var fra1 = (List<strekning>)Session["drop1"]; //har bare prøvd noe her

        //    //antallPers
        //    Session["antall"] = Request.Form["antallPersoner"];


        //    //Det tor skrev
        //    //Session["hei"] = alleFly;

        //    //var allefly1 = (List<strekning>)Session["hei"];



        //    //var allefly1 = (List<strekning>)Session["hei"];

        //    return View();
        //}
        //}

        //public ActionResult KundeRegistrer(Kunde innKunde)
        //{
        //    using (var db = new DBContext())
        //    {
        //        try
        //        {
        //            db.Kunder.Add(innKunde);
        //            db.SaveChanges();
        //        }
        //        catch (Exception feil)
        //        {

        //        }
        //    }
        //    return RedirectToAction("Liste");
        //}


        public string hentAlleFraFlyplasser()
        {
            using (var db = new DBContext())
            {
                List<strekning> alleFly = db.Strekning.ToList();
                //Session["hei"] = alleFly;

                //var allefly1 = (List<strekning>)Session["hei"];

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
                    f => f.tilFlyplass == tilFlyPlass && f.fraFlyplass == fraFlyplass && f.dato == dato && f.antallLedigeSeter >= antallLedigeSeter) .ToList();

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleFly);
            }
        }

        [HttpPost]
        public ActionResult Betaling(Models.BetalingsInformasjon innBetaling)
        {
            using (var db = new Models.DBContext())
            {
                try
                {
                    db.Betalinger.Add(innBetaling);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    // her bør det komme noe mer
                }
            }
            return RedirectToAction("Liste");
            //Dette må vel Redirect til en side der det står «Takk for din bestilling!»
        }


    }
}