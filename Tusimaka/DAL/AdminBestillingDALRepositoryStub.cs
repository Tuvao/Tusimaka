using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminBestillingDALRepositoryStub : DAL.IAdminBestillingRepository
    {

        public bool endreKunde(int id, Kunde innKunde)
        {

        }
        public List<KundeBestillinger> hentKundesFlyBestillinger(int id)
        {

        }
        public bool LagreAdminFlyBestilling(int id, FlyBestillinger nyBestilling)
        {

        }
        public bool SlettKundeBestilling(int id)
        {

        }
    }
}
