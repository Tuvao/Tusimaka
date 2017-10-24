using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class AdminFlyruterBLL : BLL.IAdminFlyruterLogikk
    {
        private IAdminFlyruterRepository _repository;

        public AdminFlyruterBLL()
        {
            _repository = new AdminFlyruterDAL();
        }

        public AdminFlyruterBLL(IAdminFlyruterRepository stub)
        {
            _repository = stub;
        }
        public List<Strekning> hentAlleFlyruter()
        {
            List<Strekning> alleFlyruter = _repository.hentAlleFlyruter();
            return alleFlyruter;
        }
        public bool lagreFlyrute(Strekning innFlyrute)
        {
            return _repository.lagreFlyrute(innFlyrute);
        }
        public bool endreFlyrute(int id, Strekning innFlytur)
        {
            return _repository.endreFlyrute(id, innFlytur);
        }
        public bool slettFlyrute(int slettFlyruteId)
        {
            return _repository.slettFlyrute(slettFlyruteId);
        }
        public Strekning hentDenneFlyruten(int id)
        {
            return _repository.hentDenneFlyruten(id);
        }
    }
}
