using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tusimaka.Models
{
    public class DBInit : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            var Strekning1 = new strekning { fraFlyplass = "Bergen", tilFlyplass = "Oslo", dato = "20.10.2017", tid = "12:30", pris = "2350", antallLedigeSeter= 50};
            var Strekning2 = new strekning { fraFlyplass = "Oslo", tilFlyplass = "Trondheim", dato = "20.10.2017", tid = "12:00", pris = "2250", antallLedigeSeter = 60 };
            var Strekning3 = new strekning { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "20.10.2017", tid = "13:00", pris = "2150", antallLedigeSeter = 34 };
            var Strekning4 = new strekning { fraFlyplass = "Bergen", tilFlyplass = "Trondheim", dato = "20.10.2017", tid = "14:00", pris = "1450", antallLedigeSeter = 90 };
            var Strekning5 = new strekning { fraFlyplass = "Oslo", tilFlyplass = "Bergen", dato = "20.10.2017", tid = "14:00", pris = "1450", antallLedigeSeter = 12 };
            context.Strekning.Add(Strekning1);
            context.Strekning.Add(Strekning2);
            context.Strekning.Add(Strekning3);
            context.Strekning.Add(Strekning4);
            context.Strekning.Add(Strekning5);
            base.Seed(context);
        }
    }
    
}