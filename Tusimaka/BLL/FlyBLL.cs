using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;

namespace Tusimaka.BLL
{
    public class FlyBLL
    {
        public string hentAlleFraFlyplasser()
        {
            var flyDAL = new FlyDAL();
            return flyDAL.hentAlleFraFlyplasser();
        }
        public string hentTilFlyplasser(string fraFlyPlass)
        {
            var flyDAL = new FlyDAL();
            return flyDAL.hentTilFlyplasser(fraFlyPlass);
        }
        public string hentStrekning(string fraFlyplass, string tilFlyPlass, string dato, int antallLedigeSeter)
        {
            var flyDAL = new FlyDAL();
            return flyDAL.hentStrekning(fraFlyplass, tilFlyPlass, dato, antallLedigeSeter);
        }
        public string hentRetur()
        {
            var flyDAL = new FlyDAL();
            return flyDAL.hentRetur();
        }
    }
}
