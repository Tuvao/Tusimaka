﻿using System;
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
                    nyKunde.epost = innKunde.Epost;
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
                //finner siste kunde registrert i kunde tabellen i DB
                int kundeId = db.Kunder.Max(k => k.kundeID);
                //henter ut registrert informasjon om ønsket kunde.
                Models.Kunder hentEnKunde = db.Kunder.FirstOrDefault(k => k.kundeID == kundeId);
                return hentEnKunde;
            }
        }
    }
}