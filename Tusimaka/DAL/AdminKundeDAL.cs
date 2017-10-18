using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminKundeDAL
    {
        public List<Kunde> hentAlleKunder()
        {
            using (var db = new DBContext())
            {
                List<Kunde> alleKunder = db.Kunder.Select(k => new Kunde()
                {
                    KundeID = k.kundeID,
                    Fornavn = k.fornavn,
                    Etternavn = k.etternavn,
                    Epost = k.epost,
                    Kjonn = k.kjonn
                }).ToList();
                return alleKunder;
            }
        }
        public bool slettKunde(int slettId)
        {
            var db = new DBContext();
            try
            {
                Kunder slettKunde = db.Kunder.Find(slettId);
                db.Kunder.Remove(slettKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

    }
}
