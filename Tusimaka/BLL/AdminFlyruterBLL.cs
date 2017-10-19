using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;

namespace Tusimaka.BLL
{
    public class AdminFlyruterBLL
    {
        public List<Model.strekning> hentAlleFlyruter()
        {
            var flyruterDAL = new AdminFlyruterDAL();
            List<Model.strekning> alleFlyruter = flyruterDAL.hentAlleFlyruter();
            return alleFlyruter;
        }
        public bool lagreFlyrute(Model.strekning innFlyrute)
        {
            var flyruteDAL = new AdminFlyruterDAL();
            return flyruteDAL.lagreFlyrute(innFlyrute);
        }

        public bool slettFlyrute(int slettFlyruteId)
        {
            var adminFlyruteDAL = new AdminFlyruterDAL();
            return adminFlyruteDAL.slettFlyrute(slettFlyruteId);
        }
    }
}
