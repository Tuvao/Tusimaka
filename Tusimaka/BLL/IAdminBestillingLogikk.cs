using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;
using Tusimaka.BLL;

namespace Tusimaka.BLL
{
    public interface IAdminBestillingLogikk
    {
        List<KundeBestillinger> hentKundesFlyBestillinger(int id);
        bool LagreAdminFlyBestilling(int id, FlyBestillinger nyBestilling);
        bool SlettKundeBestilling(int id);
    }
}
