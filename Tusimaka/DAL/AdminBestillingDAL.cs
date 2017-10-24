using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        ok.StrekningsID = i.FlyBestilling.StrekningsID;
                        ok.FraFlyplass = i.FlyBestilling.Strekninger.fraFlyplass;
                        ok.TilFlyplass = i.FlyBestilling.Strekninger.tilFlyplass;
                        ok.Dato = i.FlyBestilling.Strekninger.dato;
                        ok.Tid = i.FlyBestilling.Strekninger.tid;
                        ok.Pris = i.FlyBestilling.Strekninger.pris;
                        ok.AntallPersoner = i.FlyBestilling.antallPersoner;
                        listeKundesFlyBestillinger.Add(ok);
                    }
                    return listeKundesFlyBestillinger;
                }
                catch (Exception feil)
                {
                    string path = @"C:\Users\Bruker\source\repos\Tusimaka\logg.txt";
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return new List<KundeBestillinger>();
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
                    string path = @"C:\Users\Bruker\source\repos\Tusimaka\logg.txt";
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return false;
                }
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
                string path = @"C:\Users\Bruker\source\repos\Tusimaka\logg.txt";
                string text = feil.ToString();
                File.AppendAllText(path, text);
                return false;
            }
        }
    }
}
