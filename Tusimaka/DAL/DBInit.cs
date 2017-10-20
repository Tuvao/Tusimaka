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
            //var Strekning1 = new strekning { fraFlyplass = "Bergen", tilFlyplass = "Oslo", dato = "2017-10-20", tid = "12:30", pris = "2350", flyTid = 45, antallLedigeSeter = 4 };
            //var Strekning2 = new strekning { fraFlyplass = "Oslo", tilFlyplass = "Trondheim", dato = "2017-10-20", tid = "12:00", pris = "2250", flyTid = 55, antallLedigeSeter = 4 };
            //var Strekning3 = new strekning { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "2017-10-20", tid = "13:00", pris = "2150", flyTid = 45, antallLedigeSeter = 4 };
            //var Strekning4 = new strekning { fraFlyplass = "Bergen", tilFlyplass = "Trondheim", dato = "2017-10-20", tid = "14:00", pris = "1450", flyTid = 60, antallLedigeSeter = 60 };
            //var Strekning5 = new strekning { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "2017-10-20", tid = "14:00", pris = "1450", flyTid = 45, antallLedigeSeter = 60 };
            //var Strekning6 = new strekning { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "2017-10-21", tid = "17:00", pris = "2450", flyTid = 45, antallLedigeSeter = 60 };
            //var Strekning7 = new strekning { fraFlyplass = "Bergen", tilFlyplass = "Oslo", dato = "2017-10-21", tid = "14:00", pris = "1450", flyTid = 45, antallLedigeSeter = 60 };
            //var Strekning8 = new strekning { fraFlyplass = "Oslo", tilFlyplass = "Trondheim", dato = "2017-10-21", tid = "17:00", pris = "1250", flyTid = 55, antallLedigeSeter = 60 };
            //var Strekning9 = new strekning { fraFlyplass = "Trondheim", tilFlyplass = "Oslo", dato = "2017-10-21", tid = "09:00", pris = "1950", flyTid = 55, antallLedigeSeter = 60 };
            //var Strekning10 = new strekning { fraFlyplass = "Bergen", tilFlyplass = "Trondheim", dato = "2017-10-21", tid = "22:55", pris = "2450", flyTid = 60, antallLedigeSeter = 60 };
            //var Strekning11 = new strekning { fraFlyplass = "Trondheim", tilFlyplass = "Bergen", dato = "2017-10-21", tid = "17:00", pris = "1750", flyTid = 60, antallLedigeSeter = 60 };
            //context.Strekning.Add(Strekning1);
            //context.Strekning.Add(Strekning2);
            //context.Strekning.Add(Strekning3);
            //context.Strekning.Add(Strekning4);
            //context.Strekning.Add(Strekning5);
            //context.Strekning.Add(Strekning6);
            //context.Strekning.Add(Strekning7);
            //context.Strekning.Add(Strekning8);
            //context.Strekning.Add(Strekning9);
            //context.Strekning.Add(Strekning10);
            //context.Strekning.Add(Strekning11);

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