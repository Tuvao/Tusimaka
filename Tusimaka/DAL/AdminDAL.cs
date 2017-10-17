using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tusimaka.DAL
{
    public class AdminDAL
    {

        private static bool Bruker_i_DB(bruker innBruker)
        {
            using (var db = new BrukerContext())
            {
                byte[] passordDb = lagHash(innBruker.Passord);
                dbBruker funnetBruker = db.Brukere.FirstOrDefault
                (b => b.Passord == passordDb && b.Navn == innBruker.Navn);
                if (funnetBruker == null)
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
