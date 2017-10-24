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
                StrekningsID = 1,
                FraFlyplass = "Bergen",
                TilFlyplass = "Oslo",
                Dato = "2017-10-20",
                Tid = "12:30",
                Pris = 1234,
                FlyTid = 45,
                AntallLedigeSeter = 4
            };
            flyListe.Add(flyrute1);
            flyListe.Add(flyrute1);
            flyListe.Add(flyrute1);
            return flyListe;
        }
        public bool lagreFlyrute(Strekning innFlyrute)
        {
            if(innFlyrute.FraFlyplass == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool slettFlyrute(int id)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool endreFlyrute(int id, Strekning innFlyrute)
        {
            if (id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Strekning hentDenneFlyruten(int id)
        {
            if (id == 0)
            {
                var flyrute = new Strekning();
                flyrute.StrekningsID = 0;
                return flyrute;
            }
            else
            {
                var flyrute = new Strekning()
                {
                    StrekningsID = 1,
                    FraFlyplass = "Bergen",
                    TilFlyplass = "Oslo",
                    Dato = "2017-10-20",
                    Tid = "12:30",
                    Pris = 1234,
                    FlyTid = 45,
                    AntallLedigeSeter = 4
                };
                return flyrute;
            }
        }
    }
}
