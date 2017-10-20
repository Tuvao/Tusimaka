using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tusimaka.DAL
{
    public class AdminFlyruterDAL
    {
        public List<Model.strekning> hentAlleFlyruter()
        {
            using (var db = new DBContext())
            {
                List<Model.strekning> alleStrekninger = db.Strekning.Select(s => new Model.strekning()
                {
                    StrekningsID = s.StrekningsID,
                    tilFlyplass = s.tilFlyplass,
                    fraFlyplass = s.fraFlyplass,
                    dato = s.dato,
                    tid = s.tid,
                    pris = s.pris,
                    flyTid = s.flyTid,
                    antallLedigeSeter = s.antallLedigeSeter
                }).ToList();
                return alleStrekninger;
            }
        }
        public bool lagreFlyrute(Model.strekning innFlyrute)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var nyFlyruter = new strekning();
                    nyFlyruter.tilFlyplass = innFlyrute.tilFlyplass;
                    nyFlyruter.fraFlyplass = innFlyrute.fraFlyplass;
                    nyFlyruter.dato = innFlyrute.dato;
                    nyFlyruter.tid = innFlyrute.tid;
                    nyFlyruter.pris = innFlyrute.pris;
                    nyFlyruter.flyTid = innFlyrute.flyTid;
                    nyFlyruter.antallLedigeSeter = innFlyrute.antallLedigeSeter;

                    db.Strekning.Add(nyFlyruter);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }
        public bool slettFlyrute(int slettFlyruteId)
        {
            var db = new DBContext();
            try
            {
                strekning slettFlyrute = db.Strekning.Find(slettFlyruteId);
                db.Strekning.Remove(slettFlyrute);
                db.SaveChanges();
                Console.Write("riktig");
                return true;
            }
            catch (Exception feil)
            {
                Console.Write("feil");
                return false;
            }
        }
    }
}
