using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class AdminBestillingBLL
    {
        public List<KundeBestillinger> hentKundesFlyBestillinger(int id)
        {
            var adminBestillingDAL = new AdminBestillingDAL();
            List<KundeBestillinger> hentKundensFlyBestillinger = adminBestillingDAL.hentKundesFlyBestillinger(id);
            return (hentKundensFlyBestillinger);
        }
        public bool LagreAdminFlyBestilling(int id, FlyBestillinger nyBestilling)
        {
            var adminBestillDAL = new AdminBestillingDAL();
            return adminBestillDAL.LagreAdminFlyBestilling(id, nyBestilling);
        }
        public bool SlettKundeBestilling(int id)
        {
            var adminBestillDAL = new AdminBestillingDAL();
            return adminBestillDAL.SlettKundeBestilling(id);
        }
    }
}
