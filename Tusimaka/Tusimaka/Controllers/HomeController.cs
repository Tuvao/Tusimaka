using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Tusimaka.BLL;
using Tusimaka.Model;

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
            //henter data fra utfylt skjema i Bestill siden, lagrer i FlyBestilling tabell i DB
            //om OK, sender videre til neste side. 
            //selve funksjonene gjøres i DB.cs
            var db = new BestillingBLL();
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
            return View();
        }
        
        [HttpPost]
        public ActionResult KundeRegistrering(Kunde innKunde)
        {
            //henter data fra utfylt skjema i KundeRegistrering siden, lagrer i Kunde tabell i DB
            //om OK, sender videre til neste side. 
            var db = new KundeBLL();
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
        public ActionResult RegistrerBetaling(Model.BetalingsInformasjon innBetaling, Model.FlyBestillingKunde flyBestilling)
        {
            //henter data fra utfylt skjema i RegistrerBetaling siden
            //selve funksjonene gjøres i DB.cs
            //kobler først KundeID mot FlyBestillingsID i hjelpetabellen FlyBestillingKunde i DB
            //om OK, lagres betalingsinformasjon i BetalingsInfo i tabellen i DB. 
            //sender videre til neste side om OK
            Console.WriteLine("Regbetalingsview");
            var db = new BestillingBLL();
            bool OK2 = db.lagreKundeIdMotFlyBestilling();
            if (OK2)
            {
                Console.WriteLine("LagreKundeID funker");
                var db2 = new BetalingBLL();
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
            //Lister ut og tilgjengeliggjør dataene fra ønsket kunde i Viewet til Bekreftelse
            var db = new KundeBLL();
            Kunde hentEnKunde = db.hentEnKunde();
            return View(hentEnKunde);
        }
        public string hentAlleFraFlyplasser()
        {
            var flyBLL = new FlyBLL();
            return flyBLL.hentAlleFraFlyplasser();
        }
        public string hentTilFlyplasser(string fraFlyPlass)
        {
            var flyBLL = new FlyBLL();
            return flyBLL.hentTilFlyplasser(fraFlyPlass);
        }
        public string hentStrekning(string fraFlyplass, string tilFlyPlass, string dato, int antallLedigeSeter)
        {
            var flyBLL = new FlyBLL();
            return flyBLL.hentStrekning(fraFlyplass, tilFlyPlass, dato, antallLedigeSeter);
        }
        public string hentRetur()
        {
            var flyBLL = new FlyBLL();
            return flyBLL.hentRetur();
        }
        public string hentAntallPersoner()
        {
            var BestillBLL = new BestillingBLL();
            return BestillBLL.hentAntallPersoner();
        }
        public string hentReferanseNR()
        {
            var BestillBLL = new BestillingBLL();
            return BestillBLL.hentReferanseNR();
        }
        public string hentBestilling()
        {
            var BestillBLL = new BestillingBLL();
            return BestillBLL.hentBestilling();
        }
    }
}