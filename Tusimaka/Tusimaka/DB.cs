using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tusimaka.Models;

namespace Tusimaka
{
    public class DB
    {
        //public List<Kunde> alleKunder()
        //{
        //    using (var db = new DBContext())
        //    {
        //        List<Kunde> alleKunder = db.Kunder.Select(k => new Kunde
        //        {
        //            KundeID = k.kundeID,
        //            Fornavn = k.fornavn,
        //            Etternavn = k.etternavn,
        //            Kjonn = k.kjonn
        //        }).ToList();

        //        return alleKunder;
        //    }
        //}

        public bool lagreKunde(Kunde innKunde)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var nyKunde = new Kunder();
                    nyKunde.fornavn = innKunde.Fornavn;
                    nyKunde.etternavn = innKunde.Etternavn;
                    nyKunde.kjonn = innKunde.Kjonn;
                    
                    db.Kunder.Add(nyKunde);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }
        //public List<FlyBestillinger> alleFlyBestillinger()
        //{
        //    using (var db = new DBContext())
        //    {
        //        List<FlyBestillinger> alleFlyBestillinger = db.FlyBestilling.Select(f => new FlyBestillinger
        //        {
        //            FlyBestillingsID = f.flyBestillingsID,
        //            KundeID = f.kundeID,
        //            StrekningsID = f.strekningsID,
        //            AntallPersoner = f.antallPersoner,
        //            ReturID = f.returID
        //        }).ToList();

        //        return alleFlyBestillinger;
        //    }
        //}
    }
}