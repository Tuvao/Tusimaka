using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminRepositoryStub : DAL.IAdminRepository
    {
        public bool Bruker_i_DB(AdminBruker innAdminBruker)
        {
            if(innAdminBruker.Brukernavn == "Brukernavn" && innAdminBruker.Passord == "Passord")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
