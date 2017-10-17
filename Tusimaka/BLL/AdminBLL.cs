using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.BLL
{
    public class AdminBLL
    {
        public bool BrukerIDB(AdminBruker innAdminBruker)
        {
            var adminDAL = new AdminDAL();
            return adminDAL.BrukerIDB(innAdminBruker);
        }
    }
}
