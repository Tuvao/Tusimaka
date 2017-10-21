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
        public List<int> hentFlybestillinger(int id)
        {
            var AdminBestillingDAL = new AdminBestillingDAL();
            List<int> alleFlybestillingKunder = AdminBestillingDAL.hentFlybestillinger(id);
            return alleFlybestillingKunder;
        }
        //public List<FlyBestillingKunde> test(int id)
        //{
        //    var adminBestillingDAL = new AdminBestillingDAL();
        //    List<FlyBestillingKunde> alleBestillinger = adminBestillingDAL.test(id);
        //    return alleBestillinger;
        //}
    }
}
