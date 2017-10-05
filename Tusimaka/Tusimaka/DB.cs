using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tusimaka.Models;

namespace Tusimaka
{
    public class DB
    {
        public Kunder hentEnKunde()
        {
            using (var db = new DBContext())
            {
                int kundeId = db.Kunder.Max(k => k.kundeID);
                Models.Kunder hentEnKunde = db.Kunder.FirstOrDefault(k => k.kundeID == kundeId);
                return hentEnKunde;
            }
        }

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

        public bool lagreFlyBestilling(FlyBestillinger innFlyBestilling)
        {
            using (var db = new DBContext())
            {
                try
                {
                    int kundeId = db.Kunder.Max(k => k.kundeID);
                    
                    //int strekning = db.Strekning.Where(s => s.StrekningsID);
                    //var strekningsId = db.Strekning.Where(s => s.StrekningsID == strekning).Select(s => s.StrekningsID).First();

                    var nyFlyBestilling = new FlyBestilling();
                    nyFlyBestilling.kundeID = kundeId;
                    nyFlyBestilling.strekningsID = innFlyBestilling.StrekningsID;
                    nyFlyBestilling.antallPersoner = innFlyBestilling.AntallPersoner;
                    
                    if (innFlyBestilling.ReturID != null)
                    {
                        nyFlyBestilling.returID = innFlyBestilling.ReturID;
                    }
                    db.FlyBestilling.Add(nyFlyBestilling);

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