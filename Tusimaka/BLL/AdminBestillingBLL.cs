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

            //Jeg har kommentert ut det vi har gjort tidligere

            public List<KundeBestillinger> hentKundesFlyBestillinger(int id)
            {
                //er litt usikker på om det jeg har gjort her er korrekt
                //var adminBestillingDAL = new AdminBestillingDAL();
                List<KundeBestillinger> hentKundensFlyBestillinger = _repository.hentKundesFlyBestillinger(id);
                return (hentKundensFlyBestillinger);
            }
            public bool LagreAdminFlyBestilling(int id, FlyBestillinger nyBestilling)
            {
                //var adminBestillDAL = new AdminBestillingDAL();
                return _repository.LagreAdminFlyBestilling(id, nyBestilling);
            }
            public bool SlettKundeBestilling(int id)
            {
                //var adminBestillDAL = new AdminBestillingDAL();
                return _repository.SlettKundeBestilling(id);
            }
    }
}
