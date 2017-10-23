using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;
using Tusimaka.BLL;

namespace Tusimaka.BLL
{
    public interface IAdminKundeLogikk
    {
        List<Kunde> hentAlleKunder();
        bool slettKunde(int id);
        bool endreKunde(int id, Kunde innKunde);
        Kunde hentDenneKunden(int id);

    }
}
