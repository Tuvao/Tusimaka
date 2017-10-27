using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminKundeDALRepositoryStub : DAL.IAdminKundeRepository
    {
        public List<Kunde> hentAlleKunder()
        {
            var kundeListe = new List<Kunde>();
            var kunde = new Kunde()
            {
                KundeID = 1,
                Fornavn = "Helene",
                Etternavn = "Andersen",
                Epost = "helene@andersen.no",
                Kjonn = "Kvinne"

            };
            
            kundeListe.Add(kunde);
            kundeListe.Add(kunde);
            kundeListe.Add(kunde);
            return kundeListe;
        }
        public bool slettKunde(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            if (id == 0 || innKunde.Fornavn == "" || innKunde.Etternavn == "" || innKunde.Epost == "" || innKunde.Kjonn == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Kunde hentDenneKunden(int id)
        {
            if (id == 0)
            {
                var kunde = new Kunde();
                kunde.KundeID = 0;
                return kunde;
            }
            else
            {
                var kunde = new Kunde()
                {
                    KundeID = 1,
                    Fornavn = "Knut",
                    Etternavn = "Fredriksen",
                    Epost = "knut@fredriksen.no",
                    Kjonn = "Mann"
                };
                return kunde;
            }
        }
    }
}
