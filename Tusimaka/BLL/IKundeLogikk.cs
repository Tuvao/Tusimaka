using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public interface IKundeLogikk
    {
        bool lagreKunde(Kunde innKunde);
        Kunde hentEnKunde();

    }
}
