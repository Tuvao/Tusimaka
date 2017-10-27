using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminBestillingDAL : DAL.IAdminBestillingRepository
    {
        public List<KundeBestillinger> hentKundesFlyBestillinger(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    List<KundeBestillinger> listeKundesFlyBestillinger = new List<KundeBestillinger>();
                    List<FlyBestillingKunder> hjelpetabell = db.FlyBestillingKunder.Where(fbk => fbk.KundeID == id).ToList();
                    foreach (var i in hjelpetabell)
                    {
                        KundeBestillinger ok = new KundeBestillinger();
                        ok.KundeID = i.KundeID;
                        ok.Fornavn = i.Kunder.fornavn;
                        ok.Etternavn = i.Kunder.etternavn;
                        if (i.FlyBestilling.ReturID != null)
                        {
                            ok.StrekningsID= i.FlyBestilling.ReturID.Value;
                        }
                        else
                        {
                            ok.StrekningsID = i.FlyBestilling.StrekningsID;
                        }
                        ok.FraFlyplass = i.FlyBestilling.Strekninger.fraFlyplass;
                        ok.TilFlyplass = i.FlyBestilling.Strekninger.tilFlyplass;
                        ok.Dato = i.FlyBestilling.Strekninger.dato;
                        ok.Tid = i.FlyBestilling.Strekninger.tid;
                        ok.Pris = i.FlyBestilling.Strekninger.pris;
                        ok.AntallPersoner = i.FlyBestilling.antallPersoner;
                        List<BetalingsInfo> betalingsinfo = db.BetalingsInfo.Where(bi => bi.FlyBestillingsID == i.FlyBestillingsID).ToList();
                        foreach (var b in betalingsinfo)
                        {
                            string kontonrString = b.Kortnummer.ToString();
                            string skjultKontonr = "";
                            for (var bokstavI = 0; bokstavI< kontonrString.Length; bokstavI++)
                            {
                                if (bokstavI % 4 == 0)
                                {
                                    skjultKontonr += " ";
                                }
                                if(bokstavI < kontonrString.Length - 4)
                                {
                                    skjultKontonr += "x";
                                }
                                else
                                {
                                    skjultKontonr += kontonrString[bokstavI];
                                }
                            }
                            ok.Kortnummer = skjultKontonr;
                            ok.Korttype = b.Korttype;
                        }
                        
                        listeKundesFlyBestillinger.Add(ok);
                    }
                    return listeKundesFlyBestillinger;
                }
                catch (Exception feil)
                {
                    string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return null;
                }
            }
        }
        public bool LagreAdminFlyBestilling(int id, FlyBestillinger nyBestilling)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var nyFlyBestilling = new FlyBestilling();
                    nyFlyBestilling.StrekningsID = nyBestilling.StrekningsID;
                    nyFlyBestilling.antallPersoner = nyBestilling.AntallPersoner;

                    if (nyBestilling.ReturID != null)
                    {
                        nyFlyBestilling.ReturID = nyBestilling.ReturID;
                    }

                    db.FlyBestilling.Add(nyFlyBestilling);
                    db.SaveChanges();

                    Kunder denneKunden = db.Kunder.Find(id);

                    var nyAdminFlyBestillingKunde = new FlyBestillingKunder();
                    nyAdminFlyBestillingKunde.FlyBestillingsID = nyFlyBestilling.FlyBestillingsID; 
                    nyAdminFlyBestillingKunde.KundeID = denneKunden.KundeID;

                    db.FlyBestillingKunder.Add(nyAdminFlyBestillingKunde);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return false;
                }
            }
        }
        public bool endreKundeBestilling(int id, KundeBestillinger innBestillling)
        {
            var db = new DBContext();
            try
            {
                FlyBestillingKunder hjelpetabell = db.FlyBestillingKunder.Find(id);
                hjelpetabell.KundeID = innBestillling.KundeID;
                hjelpetabell.Kunder.fornavn = innBestillling.Fornavn;
                hjelpetabell.Kunder.etternavn = innBestillling.Etternavn;
                hjelpetabell.FlyBestilling.Strekninger.fraFlyplass = innBestillling.FraFlyplass;
                hjelpetabell.FlyBestilling.Strekninger.tilFlyplass = innBestillling.TilFlyplass;
                hjelpetabell.FlyBestilling.Strekninger.dato = innBestillling.Dato;
                hjelpetabell.FlyBestilling.Strekninger.tid = innBestillling.Tid;
                hjelpetabell.FlyBestilling.Strekninger.pris = innBestillling.Pris;
                hjelpetabell.FlyBestilling.antallPersoner = innBestillling.AntallPersoner;
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                string text = feil.ToString();
                File.AppendAllText(path, text);
                return false;
            }
        }
        public bool SlettKundeBestilling(int id)
        {
            var db = new DBContext();
            try
            {
                FlyBestillingKunder slettFraHjelpetabell = db.FlyBestillingKunder.Find(id);
                db.FlyBestillingKunder.Remove(slettFraHjelpetabell);
                FlyBestilling slettKundeBestilling = db.FlyBestilling.Find(slettFraHjelpetabell.FlyBestillingsID);
                db.FlyBestilling.Remove(slettKundeBestilling);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                string text = feil.ToString();
                File.AppendAllText(path, text);
                return false;
            }
        }
        
        public bool lagreBetalingsinformasjon(int id, BetalingsInformasjon innBetaling)
        {
            using (var db = new DBContext())
            {
                try
                {
                    FlyBestilling flyBestilling = db.FlyBestilling.Find(id);

                    var nyBetaling = new BetalingsInfo();
                    nyBetaling.FlyBestillingsID = flyBestilling.FlyBestillingsID;
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
                    string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return false;
                }
            }
        }
    }
}
