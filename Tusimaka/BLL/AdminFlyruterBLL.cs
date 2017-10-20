using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class AdminFlyruterBLL
    {
        public List<Strekning> hentAlleFlyruter()
        {
            var flyruterDAL = new AdminFlyruterDAL();
            List<Strekning> alleFlyruter = flyruterDAL.hentAlleFlyruter();
            return alleFlyruter;
        }
        public bool lagreFlyrute(Strekning innFlyrute)
        {
            var flyruteDAL = new AdminFlyruterDAL();
            return flyruteDAL.lagreFlyrute(innFlyrute);
        }
        public bool endreFlyrute(int id, Strekning innFlytur)
        {
            var adminFlyruteDAL = new AdminFlyruterDAL();
            return adminFlyruteDAL.endreFlyrute(id, innFlytur);
        }
        public bool slettFlyrute(int slettFlyruteId)
        {
            var adminFlyruteDAL = new AdminFlyruterDAL();
            return adminFlyruteDAL.slettFlyrute(slettFlyruteId);
        }
        public Strekning hentDenneFlyruten(int flyid)
        {
            var adminFlyruteDAL = new AdminFlyruterDAL();
            return adminFlyruteDAL.hentDenneFlyruten(flyid);
        }
    }
}
