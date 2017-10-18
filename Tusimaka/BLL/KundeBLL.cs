using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class KundeBLL
    {
        //lagrekunde
        public bool lagreKunde(Kunde innKunde)
        {
            var kundeDAL = new KundeDAL();
            return kundeDAL.lagreKunde(innKunde);
        }
        public Kunde hentEnKunde()
        {
            var kundeDAL = new KundeDAL();
            return kundeDAL.hentEnKunde();
        }
        public List<Kunde> hentAlleKunder()
        {
            var kundeDAL = new KundeDAL();
            List<Kunde> alleKunder = kundeDAL.hentAlleKunder();
            return alleKunder;
        }

    }
}
