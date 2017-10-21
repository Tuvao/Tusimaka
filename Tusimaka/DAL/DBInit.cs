using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tusimaka.DAL
{
    public class DBInit : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            var Strekning1 = new Strekninger { fraFlyplass = "Bergen", tilFlyplass = "Oslo", dato = "2017-10-20", tid = "12:30", pris = 2350, flyTid = 45, antallLedigeSeter = 4 };
            var Strekning2 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Trondheim", dato = "2017-10-20", tid = "12:00", pris = 2250, flyTid = 55, antallLedigeSeter = 4 };
            var Strekning3 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "2017-10-20", tid = "13:00", pris = 2150, flyTid = 45, antallLedigeSeter = 4 };
            var Strekning4 = new Strekninger { fraFlyplass = "Bergen", tilFlyplass = "Trondheim", dato = "2017-10-20", tid = "14:00", pris = 1450, flyTid = 60, antallLedigeSeter = 60 };
            var Strekning5 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "2017-10-20", tid = "14:00", pris = 1450, flyTid = 45, antallLedigeSeter = 60 };
            var Strekning6 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "2017-10-21", tid = "17:00", pris = 2450, flyTid = 45, antallLedigeSeter = 60 };
            var Strekning7 = new Strekninger { fraFlyplass = "Bergen", tilFlyplass = "Oslo", dato = "2017-10-21", tid = "14:00", pris = 1450, flyTid = 45, antallLedigeSeter = 60 };
            var Strekning8 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Trondheim", dato = "2017-10-21", tid = "17:00", pris = 1250, flyTid = 55, antallLedigeSeter = 60 };
            var Strekning9 = new Strekninger { fraFlyplass = "Trondheim", tilFlyplass = "Oslo", dato = "2017-10-21", tid = "09:00", pris = 1950, flyTid = 55, antallLedigeSeter = 60 };
            var Strekning10 = new Strekninger { fraFlyplass = "Bergen", tilFlyplass = "Trondheim", dato = "2017-10-21", tid = "22:55", pris = 2450, flyTid = 60, antallLedigeSeter = 60 };
            var Strekning11 = new Strekninger { fraFlyplass = "Trondheim", tilFlyplass = "Bergen", dato = "2017-10-21", tid = "17:00", pris = 1750, flyTid = 60, antallLedigeSeter = 60 };
            context.Strekninger.Add(Strekning1);
            context.Strekninger.Add(Strekning2);
            context.Strekninger.Add(Strekning3);
            context.Strekninger.Add(Strekning4);
            context.Strekninger.Add(Strekning5);
            context.Strekninger.Add(Strekning6);
            context.Strekninger.Add(Strekning7);
            context.Strekninger.Add(Strekning8);
            context.Strekninger.Add(Strekning9);
            context.Strekninger.Add(Strekning10);
            context.Strekninger.Add(Strekning11);

            byte[] hashetPassord = lagHash("Bord321");
            var AdminBruker1 = new AdminBrukere { brukernavn = "Admin", passord = hashetPassord};
            context.AdminBrukere.Add(AdminBruker1);
            base.Seed(context);
        }
        private static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }
    }

}