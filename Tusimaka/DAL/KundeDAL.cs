using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class KundeDAL
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

        public Kunde hentEnKunde()
        {
            using (var db = new DBContext())
            {
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
        }    
    }
}
