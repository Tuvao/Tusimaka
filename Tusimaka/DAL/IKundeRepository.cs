using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public interface IKundeRepository
    {
        bool lagreKunde(Kunde innKunde);
        Kunde hentEnKunde();

    }
}
