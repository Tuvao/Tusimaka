using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public interface IAdminBestillingRepository
    {
        //bool endreKunde(int id, Kunde innKunde);
        //List<KundeBestillinger> hentKundesFlyBestillinger(int id);
        //bool LagreAdminFlyBestilling(int id, FlyBestillinger nyBestilling);
        //bool SlettKundeBestilling(int id);
        bool lagreFlyBestilling(FlyBestillinger innFlyinfo);
        bool lagreKundeIdMotFlyBestilling(Kunde innKunde, FlyBestillinger innFlyinfo);
        string hentAntallPersoner(int id);
        string hentBestilling(int id);
        string hentReferanseNR(int id);

    }
}
