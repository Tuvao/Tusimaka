using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class KundeDAL : DAL.IKundeRepository
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
                    string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return false;
                }
            }
        }

        public Kunde hentEnKunde()
        {
            using (var db = new DBContext())
            {
                try
                {
                    db.Database.Log = Console.Write;
                    //finner siste kunde registrert i kunde tabellen i DB
                    int kundeId = db.Kunder.Max(k => k.KundeID);
                    //henter ut registrert informasjon om ønsket kunde.
                    Kunder hentEnKunde = db.Kunder.FirstOrDefault(k => k.KundeID == kundeId);
                    Kunde sisteKunde = new Kunde();
                    sisteKunde.Fornavn = hentEnKunde.fornavn;
                    sisteKunde.Etternavn = hentEnKunde.etternavn;
                    sisteKunde.KundeID = hentEnKunde.KundeID;
                    sisteKunde.Epost = hentEnKunde.epost;
                    return sisteKunde;
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
    }
}
