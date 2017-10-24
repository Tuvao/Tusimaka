using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;
using Tusimaka.DAL;

namespace Tusimaka.DAL
{
    public interface IAdminFlyruterRepository
    {
        List<Strekning> hentAlleFlyruter();
        bool lagreFlyrute(Strekning innFlyrute);
        bool slettFlyrute(int id);
        bool endreFlyrute(int id, Strekning innFlyrute);
        Strekning hentDenneFlyruten(int id);

    }
}
