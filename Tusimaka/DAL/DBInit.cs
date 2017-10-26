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
            var Strekning1 = new Strekninger { fraFlyplass = "Bergen", tilFlyplass = "Oslo", dato = "2017-11-23", tid = "12:30", pris = 2350, flyTid = 45, antallLedigeSeter = 4 };
            var Strekning2 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Trondheim", dato = "2017-11-23", tid = "12:00", pris = 2250, flyTid = 55, antallLedigeSeter = 4 };
            var Strekning3 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "2017-11-23", tid = "13:00", pris = 2150, flyTid = 45, antallLedigeSeter = 4 };
            var Strekning4 = new Strekninger { fraFlyplass = "Bergen", tilFlyplass = "Trondheim", dato = "2017-11-23", tid = "14:00", pris = 1450, flyTid = 60, antallLedigeSeter = 60 };
            var Strekning5 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "2017-11-23", tid = "14:00", pris = 1450, flyTid = 45, antallLedigeSeter = 60 };
            var Strekning6 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "2017-11-24", tid = "17:00", pris = 2450, flyTid = 45, antallLedigeSeter = 60 };
            var Strekning7 = new Strekninger { fraFlyplass = "Bergen", tilFlyplass = "Oslo", dato = "2017-11-24", tid = "14:00", pris = 1450, flyTid = 45, antallLedigeSeter = 60 };
            var Strekning8 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Trondheim", dato = "2017-11-24", tid = "17:00", pris = 1250, flyTid = 55, antallLedigeSeter = 60 };
            var Strekning9 = new Strekninger { fraFlyplass = "Trondheim", tilFlyplass = "Oslo", dato = "2017-11-24", tid = "09:00", pris = 1950, flyTid = 55, antallLedigeSeter = 60 };
            var Strekning10 = new Strekninger { fraFlyplass = "Bergen", tilFlyplass = "Trondheim", dato = "2017-11-24", tid = "22:55", pris = 2450, flyTid = 60, antallLedigeSeter = 60 };
            var Strekning11 = new Strekninger { fraFlyplass = "Trondheim", tilFlyplass = "Bergen", dato = "2017-11-24", tid = "17:00", pris = 1750, flyTid = 60, antallLedigeSeter = 60 };
            var Strekning12 = new Strekninger { fraFlyplass = "Dubai", tilFlyplass = "New York", dato = "2017-11-23", tid = "14:00", pris = 5450, flyTid = 1380, antallLedigeSeter = 500 };
            var Strekning13 = new Strekninger { fraFlyplass = "New York", tilFlyplass = "Dubai", dato = "2017-11-24", tid = "17:00", pris = 5250, flyTid = 1380, antallLedigeSeter = 500 };
            var Strekning14 = new Strekninger { fraFlyplass = "Los Angeles", tilFlyplass = "Oslo", dato = "2017-11-23", tid = "09:00", pris = 3950, flyTid = 1050, antallLedigeSeter = 500 };
            var Strekning15 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Los Angeles", dato = "2017-11-23", tid = "05:05", pris = 3950, flyTid = 1050, antallLedigeSeter = 500 };
            var Strekning16 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Los Angeles", dato = "2017-11-24", tid = "05:05", pris = 3950, flyTid = 1050, antallLedigeSeter = 500 };
            var Strekning17 = new Strekninger { fraFlyplass = "Los Angeles", tilFlyplass = "Oslo", dato = "2017-11-24", tid = "04:30", pris = 3950, flyTid = 1050, antallLedigeSeter = 500 };
            var Strekning18 = new Strekninger { fraFlyplass = "Austin", tilFlyplass = "Oslo", dato = "2017-11-23", tid = "22:55", pris = 4150, flyTid = 950, antallLedigeSeter = 500 };
            var Strekning19 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Austin", dato = "2017-11-24", tid = "09:55", pris = 4150, flyTid = 950, antallLedigeSeter = 500 };
            var Strekning20 = new Strekninger { fraFlyplass = "Austin", tilFlyplass = "Oslo", dato = "2017-11-24", tid = "04:45", pris = 4150, flyTid = 950, antallLedigeSeter = 500 };
            var Strekning21 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Austin", dato = "2017-11-23", tid = "23:55", pris = 4150, flyTid = 950, antallLedigeSeter = 500 };
            var Strekning22 = new Strekninger { fraFlyplass = "Stockholm", tilFlyplass = "Oslo", dato = "2017-11-23", tid = "07:55", pris = 1050, flyTid = 60, antallLedigeSeter = 100 };
            var Strekning23 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Stockholm", dato = "2017-11-24", tid = "15:25", pris = 1250, flyTid = 60, antallLedigeSeter = 100 };
            var Strekning24 = new Strekninger { fraFlyplass = "Oslo", tilFlyplass = "Stockholm", dato = "2017-11-23", tid = "08:45", pris = 950, flyTid = 60, antallLedigeSeter = 100 };
            var Strekning25 = new Strekninger { fraFlyplass = "Stockholm", tilFlyplass = "Oslo", dato = "2017-11-24", tid = "10:15", pris = 1150, flyTid = 60, antallLedigeSeter = 100 };
            var Strekning26 = new Strekninger { fraFlyplass = "Stockholm", tilFlyplass = "København", dato = "2017-11-23", tid = "14:05", pris = 850, flyTid = 60, antallLedigeSeter = 100 };
            var Strekning27 = new Strekninger { fraFlyplass = "København", tilFlyplass = "Stockholm", dato = "2017-11-23", tid = "09:55", pris = 950, flyTid = 60, antallLedigeSeter = 100 };
            var Strekning28 = new Strekninger { fraFlyplass = "Stockholm", tilFlyplass = "København", dato = "2017-11-24", tid = "10:05", pris = 1100, flyTid = 60, antallLedigeSeter = 100 };
            var Strekning29 = new Strekninger { fraFlyplass = "København", tilFlyplass = "Stockholm", dato = "2017-11-24", tid = "21:20", pris = 1250, flyTid = 60, antallLedigeSeter = 100 };
            var Strekning30 = new Strekninger { fraFlyplass = "Dubai", tilFlyplass = "New York", dato = "2017-11-24", tid = "14:00", pris = 5450, flyTid = 1580, antallLedigeSeter = 500 };
            var Strekning31 = new Strekninger { fraFlyplass = "New York", tilFlyplass = "Dubai", dato = "2017-11-23", tid = "17:00", pris = 5250, flyTid = 1720, antallLedigeSeter = 500 };
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
            context.Strekninger.Add(Strekning12);
            context.Strekninger.Add(Strekning13);
            context.Strekninger.Add(Strekning14);
            context.Strekninger.Add(Strekning15);
            context.Strekninger.Add(Strekning16);
            context.Strekninger.Add(Strekning17);
            context.Strekninger.Add(Strekning18);
            context.Strekninger.Add(Strekning19);
            context.Strekninger.Add(Strekning20);
            context.Strekninger.Add(Strekning21);
            context.Strekninger.Add(Strekning22);
            context.Strekninger.Add(Strekning23);
            context.Strekninger.Add(Strekning24);
            context.Strekninger.Add(Strekning25);
            context.Strekninger.Add(Strekning26);
            context.Strekninger.Add(Strekning27);
            context.Strekninger.Add(Strekning28);
            context.Strekninger.Add(Strekning29);
            context.Strekninger.Add(Strekning30);
            context.Strekninger.Add(Strekning31);

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