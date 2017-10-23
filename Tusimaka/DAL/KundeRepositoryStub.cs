using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class KundeRepositoryStub : DAL.IKundeRepository
    {
        public bool lagreKunde(Kunde innKunde)
        {
                if (innKunde.Fornavn == "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
        }

        public Kunde hentEnKunde()
        {
            var kunde = new Kunde()
            {
                KundeID = 1,
                Fornavn = "Marte",
                Etternavn = "Olsen",
                Epost = "Osloveien 82",
                Kjonn = "Kvinne"
            };
            return kunde;

        }

    }
}
