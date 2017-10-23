using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    //Må endre til KundeLogikk : BLL.IKundeLogikk
    public class KundeBLL
    {
        //lagrekunde
        public bool lagreKunde(Kunde innKunde)
        {
            var kundeDAL = new KundeDAL();
            return kundeDAL.lagreKunde(innKunde);
        }
        public Kunde hentEnKunde()
        {
            var kundeDAL = new KundeDAL();
            return kundeDAL.hentEnKunde();
        }
    }
}
   
