using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class AdminBLL : BLL.IAdminLogikk
    {
        private IAdminRepository _repository;

        public AdminBLL()
        {
            _repository = new AdminDAL();
        }

        public AdminBLL(IAdminRepository stub)
        {
            _repository = stub;
        }
        public bool Bruker_i_DB(AdminBruker innAdminBruker)
        {
            return _repository.Bruker_i_DB(innAdminBruker);
        }
    }
}
