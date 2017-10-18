using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class AdminKundeBLL
    {
        public List<Kunde> hentAlleKunder()
        {
            var kundeDAL = new AdminKundeDAL();
            List<Kunde> alleKunder = kundeDAL.hentAlleKunder();
            return alleKunder;
        }
        public bool slettKunde(int slettId)
        {
            var adminKundeDAL = new AdminKundeDAL();
            return adminKundeDAL.slettKunde(slettId);
        }
        public bool endreKunde(int slettId, Kunde innKunde)
        {
            var adminKundeDAL = new AdminKundeDAL();
            return adminKundeDAL.endreKunde(slettId, innKunde);
        }
        public Kunde hentDenneKunden(int id)
        {
            var adminKundeDAL = new AdminKundeDAL();
            return adminKundeDAL.hentDenneKunden(id);
        }

    }
}
