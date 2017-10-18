using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class BestillingBLL
    {
        public bool lagreFlyBestilling(FlyBestillinger innFlyBestilling)
        {
            var BestillDAL = new BestillingDAL();
            return BestillDAL.lagreFlyBestilling(innFlyBestilling);
        }
        public bool lagreKundeIdMotFlyBestilling()
        {
            var BestillDAL = new BestillingDAL();
            return BestillDAL.lagreKundeIdMotFlyBestilling();
        }
        public string hentAntallPersoner()
        {
            var BestillDAL = new BestillingDAL();
            return BestillDAL.hentAntallPersoner();
        }
        public string hentBestilling()
        {
            var BestillDAL = new BestillingDAL();
            return BestillDAL.hentBestilling();
        }
        public string hentReferanseNR()
        {
            var BestillDAL = new BestillingDAL();
            return BestillDAL.hentReferanseNR();
        }
    }
}
