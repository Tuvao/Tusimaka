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
        List<KundeBestillinger> hentKundesFlyBestillinger(int id);
        bool LagreAdminFlyBestilling(int id, FlyBestillinger nyBestilling);
        bool SlettKundeBestilling(int id);
        bool lagreBetalingsinformasjon(int id, BetalingsInformasjon innBetaling);
        bool endreKundeBestilling(int id, KundeBestillinger innBestillling);
    }
}
