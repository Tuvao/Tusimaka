using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminBestillingDAL
    {
        //TEST3
        public List<FlyBestillingKunde> test(int KundeId)
        {
            var db = new DBContext();

            //var enKunde = db.Kunder.Find(KundeId);

            List<FlyBestillingKunde> alleKundeBestillinger = db.FlyBestillingKunder.Where(f => f.kundeID == KundeId).Select(f => new FlyBestillingKunde()
            {
                FlyBestillingsID = f.flyBestillingsID,
                KundeID = f.kundeID
            }).ToList();
            return alleKundeBestillinger;

        }

            //Tankegang
            //public List<strekning> hentKundesFlyBestillingsID(int KundeId)
            //{
            //    using (var db = new DBContext())
            //    {

            //        //List<strekning> strekninger = new List<strekning>();
            //        //innparameter: kundeID
            //        //Finn Flybestilling knyttet til kunde i Flybestillingkunde. 
            //        //hent ut flybestillingsID fra flybestillingkunde
            //        //List flybestilling where flybestillingsID = flybestID

            //        //TEST1
            //        //List<FlyBestillingKunder> kundeSineBestillinger = db.FlyBestillingKunder.Where(f => f.kundeID == KundeId).ToList();
            //        //foreach(FlyBestillingKunder bestillinger in kundeSineBestillinger)
            //        //{
            //        //    List<FlyBestilling> flybestillingsId = db.FlyBestilling.Where(f => f.flyBestillingsID == bestillinger.flyBestillingsID).Select(f => new FlyBestilling()
            //        //    {
            //        //        flyBestillingsID = f.flyBestillingsID,
            //        //        StrekningsID = f.StrekningsID
            //        //    }).ToList();
            //        //    foreach (FlyBestilling flybestillinger in flybestillingsId)
            //        //    {
            //        //        var denneKunden = db.FlyBestilling.Find(flybestillingsId);

            //        //        if (denneKunden == null)
            //        //        {
            //        //            return null;
            //        //        }
            //        //        else
            //        //        {
            //        //            List<strekning> utBestillinger = db.Strekning.Where(s => s.StrekningsID == denneKunden.StrekningsID).Select(s => new strekning()
            //        //            {
            //        //                fraFlyplass = s.fraFlyplass,
            //        //                tilFlyplass = s.tilFlyplass,
            //        //                dato = s.dato,
            //        //                tid = s.tid,
            //        //                pris = s.pris,
            //        //                flyTid = s.flyTid,
            //        //                antallLedigeSeter = s.antallLedigeSeter
            //        //            }).ToList();
            //        //        }
            //        //    }

            //        //}
            //        //return utBestillinger.ToList();


            //        //TEST2
            //        //List<FlyBestillingKunder> kundeSineBestillinger = db.FlyBestillingKunder.Where(f => f.kundeID == KundeId).ToList();

            //        //foreach (FlyBestillingKunder bestillinger in kundeSineBestillinger)
            //        //{

            //        //    List<FlyBestilling> flybestillingsId = db.FlyBestilling.Where(f => f.flyBestillingsID == bestillinger.flyBestillingsID).ToList();

            //        //    foreach (FlyBestilling flybestillinger in flybestillingsId)
            //        //    {
            //        //        List<strekning> strekninger = db.Strekning.Where(s => s.StrekningsID == flybestillinger.StrekningsID).Select(s => new strekning()
            //        //        {
            //        //            fraFlyplass = s.fraFlyplass,
            //        //            tilFlyplass = s.tilFlyplass,
            //        //            dato = s.dato,
            //        //            tid = s.tid,
            //        //            pris = s.pris,
            //        //            flyTid = s.flyTid,
            //        //            antallLedigeSeter = s.antallLedigeSeter
            //        //        }).ToList();
            //        //    }
            //        //}
            //        //return strekninger.ToList();

            //    }
            //}
        }
}
