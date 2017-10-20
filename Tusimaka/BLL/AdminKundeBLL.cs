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
        public bool slettKunde(int id)
        {
            var adminKundeDAL = new AdminKundeDAL();
            return adminKundeDAL.slettKunde(id);
        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            var adminKundeDAL = new AdminKundeDAL();
            return adminKundeDAL.endreKunde(id, innKunde);
        }
        public Kunde hentDenneKunden(int id)
        {
            var adminKundeDAL = new AdminKundeDAL();
            return adminKundeDAL.hentDenneKunden(id);
        }

    }
}
