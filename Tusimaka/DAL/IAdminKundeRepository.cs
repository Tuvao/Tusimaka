using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public interface IAdminKundeRepository
    {
        List<Kunde> hentAlleKunder();
        bool slettKunde(int id);
        bool endreKunde(int id, Kunde innKunde);
        Kunde hentDenneKunden(int id);
    }
}
