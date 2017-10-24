using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class AdminKundeBLL : BLL.IAdminKundeLogikk
    {
        private IAdminKundeRepository _repository;

        public AdminKundeBLL()
        {
            _repository = new AdminKundeDAL();
        }

        public AdminKundeBLL(IAdminKundeRepository stub)
        {
            _repository = stub;
        }

        //Jeg har kommentert ut det vi hadde fra tidligere

        public List<Kunde> hentAlleKunder()
        {
            //var kundeDAL = new AdminKundeDAL();
            //List<Kunde> alleKunder = kundeDAL.hentAlleKunder();
            return _repository.hentAlleKunder();
        }
        public bool slettKunde(int id)
        {
            //var adminKundeDAL = new AdminKundeDAL();
            return _repository.slettKunde(id);
        }
        public bool endreKunde(int id, Kunde innKunde)
        {
            //var adminKundeDAL = new AdminKundeDAL();
            return _repository.endreKunde(id, innKunde);
        }
        public Kunde hentDenneKunden(int id)
        {
            //var adminKundeDAL = new AdminKundeDAL();
            return _repository.hentDenneKunden(id);
        }

    }
}
