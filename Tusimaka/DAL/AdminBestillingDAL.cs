using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminBestillingDAL
    {
        public List<KundeBestillinger> hentKundesFlyBestillinger(int id)
        {
            using (var db = new DBContext())
            {
                List<KundeBestillinger> listeKundesFlyBestillinger = new List<KundeBestillinger>();
                List<FlyBestillingKunder> hjelpetabell = db.FlyBestillingKunder.Where(fbk => fbk.KundeID == id).ToList();
                foreach(var i in hjelpetabell)
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
        }
    }
}
