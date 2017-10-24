using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class KundeBLL : BLL.IKundeLogikk
    {
            private IKundeRepository _repository;

            public KundeBLL()
            {
                _repository = new KundeDAL();
            }

            public KundeBLL(IKundeRepository stub)
            {
                _repository = stub;
            }

            //lagrekunde
            public bool lagreKunde(Kunde innKunde)
            {
                //var kundeDAL = new KundeDAL();
                return _repository.lagreKunde(innKunde);
            }
            public Kunde hentEnKunde()
            {
                //var kundeDAL = new KundeDAL();
                return _repository.hentEnKunde();
            }
    }
}
   
