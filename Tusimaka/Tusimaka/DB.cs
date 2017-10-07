using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Tusimaka.Models;

namespace Tusimaka
{
    public class DB
    {
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
                    nyKunde.epost = innKunde.Epost;

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
                    var nyFlyBestilling = new FlyBestilling();
                    //nyFlyBestilling.kundeID = kundeId;
                    nyFlyBestilling.StrekningsID = innFlyBestilling.StrekningsID;
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
        public bool lagreKundeIdMotFlyBestilling ()
        {
            using (var db = new DBContext())
            {
                try
                {
                    //Finner siste kundeID som ble lagt til i Kunder i DB. 
                    int kundeId = db.Kunder.Max(k => k.kundeID);
                    //Finner siste FlyBestillingsID som ble lagt til i FlyBestilling i DB.
                    int flyBestillingsId = db.FlyBestilling.Max(f => f.flyBestillingsID);

                    var nyFlyBestillingKunde = new FlyBestillingKunde();
                    nyFlyBestillingKunde.FlyBestillingsID = flyBestillingsId;
                    nyFlyBestillingKunde.KundeID = kundeId;

                    db.FlyBestillingKunde.Add(nyFlyBestillingKunde);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool lagreBetalingsinformasjon(BetalingsInformasjon innBetaling)
        {
            using (var db = new DBContext())
            {
                try
                {
                    int flyBestillingsId = db.FlyBestilling.Max(f => f.flyBestillingsID);

                    var nyBetaling = new BetalingsInfo();
                    nyBetaling.FlyBestillingsID = flyBestillingsId;
                    nyBetaling.Kortnummer = innBetaling.Kortnummer;
                    nyBetaling.Utlopsmnd = innBetaling.Utlopsmnd;
                    nyBetaling.Utlopsaar = innBetaling.Utlopsaar;
                    nyBetaling.Utlopsmnd = innBetaling.Utlopsmnd;
                    nyBetaling.CVC = innBetaling.CVC;
                    nyBetaling.Korttype = innBetaling.Korttype;

                    db.BetalingsInfo.Add(nyBetaling);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }
        public Kunder hentEnKunde()
        {
            using (var db = new DBContext())
            {
                //finner siste registrert i DB
                int kundeId = db.Kunder.Max(k => k.kundeID);
                //henter ut registrert informasjon om ønsket kunde.
                Models.Kunder hentEnKunde = db.Kunder.FirstOrDefault(k => k.kundeID == kundeId);
                return hentEnKunde;
            }
        }

        //public string hentBestilling()
        //{
        //    using (var db = new DBContext())
        //    {

        //        int flyBestillingsId = db.FlyBestilling.Max(f => f.flyBestillingsID);

        //        Models.FlyBestilling finnStrekning = db.FlyBestilling.FirstOrDefault(f => f.flyBestillingsID == flyBestillingsId);
        //        int strekningsId = finnStrekning.StrekningsID;
        //        List<strekning> finnStrekningList = db.Strekning.Where(s => s.StrekningsID == strekningsId).ToList();

        //        var jsonSerializer = new JavaScriptSerializer();
        //        return jsonSerializer.Serialize(finnStrekningList);
        //    }
        //}

    }
}