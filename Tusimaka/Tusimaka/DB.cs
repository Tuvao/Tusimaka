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

        public bool lagreFlyBestilling(FlyBestillinger innFlyBestilling, Kunde innKunder, strekning innStrekning)
        {
            using (var db = new DBContext())
            {
                try
                {
                    
                    //Models.Kunder hentEnKunde = db.Kunder.kundeID.FirstOrDefault(k => k.kundeID == kundeId);
                   

                    var nyFlyBestilling = new FlyBestilling();
                    var nyKunde = new Kunder();
                    var nyStrekning = new strekning();
                    nyFlyBestilling.antallPersoner = innFlyBestilling.AntallPersoner;
                    nyKunde.kundeID = innKunder.KundeID;
                    nyStrekning.StrekningsID = innStrekning.StrekningsID;
       
                    db.FlyBestilling.Add(nyFlyBestilling);
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