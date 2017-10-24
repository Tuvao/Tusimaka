using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminFlyruterDALRepositoryStub : DAL.IAdminFlyruterRepository
    {
        public List<Strekning> hentAlleFlyruter()
        {
            var flyListe = new List<Strekning>();
            var flyrute1 = new Strekning()
            {
                
            }

        }
        public bool lagreFlyrute(Strekning innFlyrute)
        {

        }
        public bool slettFlyrute(int id)
        {

        }
        public bool endreFlyrute(int id, Strekning innFlyrute)
        {

        }
        public Strekning hentDenneFlyruten(int id)
        {

        }
    }
}
