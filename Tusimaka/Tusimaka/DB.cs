﻿using System;
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
                //finner siste registrert i DB
                int kundeId = db.Kunder.Max(k => k.kundeID);
                //henter ut registrert informasjon om ønsket kunde.
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
        public bool registrereKundeIdMotFlyBestilling ()
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
    }
}