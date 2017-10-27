using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class AdminBestillingBLL : BLL.IAdminBestillingLogikk
    {
  
            private IAdminBestillingRepository _repository;

            public AdminBestillingBLL()
            {
                _repository = new AdminBestillingDAL();
            }

            public AdminBestillingBLL(IAdminBestillingRepository stub)
            {
                _repository = stub;
            }

            public List<KundeBestillinger> hentKundesFlyBestillinger(int id)
            {
                List<KundeBestillinger> hentKundensFlyBestillinger = _repository.hentKundesFlyBestillinger(id);
                return (hentKundensFlyBestillinger);
            }
            public bool LagreAdminFlyBestilling(int id, FlyBestillinger nyBestilling)
            {
                return _repository.LagreAdminFlyBestilling(id, nyBestilling);
            }
            public bool lagreBetalingsinformasjon(int id, BetalingsInformasjon innBetaling)
            {
                return _repository.lagreBetalingsinformasjon(id, innBetaling);
            }
            public bool SlettKundeBestilling(int id)
            {
                return _repository.SlettKundeBestilling(id);
            }
    }
}
