using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class BestillingDAL
    {
        public bool lagreFlyBestilling(FlyBestillinger innFlyBestilling)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var nyFlyBestilling = new FlyBestilling();

                    nyFlyBestilling.StrekningsID = innFlyBestilling.StrekningsID;
                    nyFlyBestilling.antallPersoner = innFlyBestilling.AntallPersoner;

                    if (innFlyBestilling.ReturID != null)
                    {
                        nyFlyBestilling.returID = innFlyBestilling.ReturID;
                    }

                    db.FlyBestilling.Add(nyFlyBestilling);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        public bool lagreKundeIdMotFlyBestilling()
        {
            using (var db = new DBContext())
            {
                try
                {
                    //Finner siste kundeID som ble lagt til i Kunder i DB. 
                    int kundeId = db.Kunder.Max(k => k.kundeID);
                    //Finner siste FlyBestillingsID som ble lagt til i FlyBestilling i DB.
                    int flyBestillingsId = db.FlyBestilling.Max(f => f.flyBestillingsID);

                    var nyFlyBestillingKunde = new FlyBestillingKunder();
                    nyFlyBestillingKunde.flyBestillingsID = flyBestillingsId;
                    nyFlyBestillingKunde.kundeID = kundeId;

                    db.FlyBestillingKunder.Add(nyFlyBestillingKunde);
                    
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }
        public string hentAntallPersoner()
        {
            using (var db = new DBContext())
            {
                int flyBestillingsId = db.FlyBestilling.Max(f => f.flyBestillingsID);
                FlyBestilling finnAntallPers = db.FlyBestilling.FirstOrDefault(f => f.flyBestillingsID == flyBestillingsId);

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(finnAntallPers);
            }
        }
        public string hentBestilling()
        {
            using (var db = new DBContext())
            {
                int flyBestillingsId = db.FlyBestilling.Max(f => f.flyBestillingsID);
                FlyBestilling finnStrekning = db.FlyBestilling.FirstOrDefault(f => f.flyBestillingsID == flyBestillingsId);
                int strekningsId = finnStrekning.StrekningsID;
                strekning finnStrekningList = db.Strekning.FirstOrDefault(s => s.StrekningsID == strekningsId);

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(finnStrekningList);
            }
        }
        public string hentReferanseNR()
        {
            using (var db = new DBContext())
            {
                int flyBestillingsId = db.FlyBestilling.Max(f => f.flyBestillingsID);
                FlyBestilling finnRefNr = db.FlyBestilling.FirstOrDefault(f => f.flyBestillingsID == flyBestillingsId);

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(finnRefNr);
            }
        }
    }
}
