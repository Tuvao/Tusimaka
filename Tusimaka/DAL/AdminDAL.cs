using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tusimaka.DAL
{
    public class AdminDAL
    {
        private static bool BrukerIDB(AdminBrukere innAdminBruker)
        {
            using (var db = new DBContext())
            {
                byte[] passordDb = lagHash(innAdminBruker.passord);
                AdminBrukere funnetAdminBruker = db.AdminBrukere.FirstOrDefault
                (b => b.passord == passordDb && b.brukernavn == innAdminBruker.brukernavn);
                if (funnetAdminBruker == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
