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
        public bool Bruker_i_DB(AdminBruker innAdminBruker)
        {
            var adminDAL = new AdminDAL();
            return adminDAL.Bruker_i_DB(innAdminBruker);
        }
    }
}
