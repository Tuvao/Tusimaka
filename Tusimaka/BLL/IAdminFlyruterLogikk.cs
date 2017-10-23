using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;
using Tusimaka.BLL;

namespace Tusimaka.BLL
{
    public interface IAdminFlyruterLogikk
    {
        List<Strekning> hentAlleFlyruter();
        bool lagreFlyrute(Strekning innFlyrute);
        bool slettFlyrute(int id);
        bool endreFlyrute(int id, Strekning innFlyrute);
        Strekning hentDenneFlyruten(int id);
    }
}
