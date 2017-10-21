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
        public bool lagreFlyBestilling(FlyBestillinger innFlyinfo)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var nyFlyBestilling = new FlyBestilling();

                    nyFlyBestilling.StrekningsID = innFlyinfo.StrekningsID;
                    nyFlyBestilling.antallPersoner = innFlyinfo.AntallPersoner;

                    if (innFlyinfo.ReturID != null)
                    {
                        nyFlyBestilling.ReturID = innFlyinfo.ReturID;
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
                    int kundeId = db.Kunder.Max(k => k.KundeID);
                    //Finner siste FlyBestillingsID som ble lagt til i FlyBestilling i DB.
                    int flyBestillingsId = db.FlyBestilling.Max(f => f.FlyBestillingsID);

                    var nyFlyBestillingKunde = new FlyBestillingKunder();
                    nyFlyBestillingKunde.FlyBestillingsID = flyBestillingsId;
                    nyFlyBestillingKunde.KundeID = kundeId;

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
                int flyBestillingsId = db.FlyBestilling.Max(f => f.FlyBestillingsID);
                FlyBestilling finnAntallPers = db.FlyBestilling.FirstOrDefault(f => f.FlyBestillingsID == flyBestillingsId);

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(finnAntallPers);
            }
        }
        public string hentBestilling()
        {
            using (var db = new DBContext())
            {
                int flyBestillingsId = db.FlyBestilling.Max(f => f.FlyBestillingsID);
                FlyBestilling finnStrekning = db.FlyBestilling.FirstOrDefault(f => f.FlyBestillingsID == flyBestillingsId);
                int strekningsId = finnStrekning.StrekningsID;
                Strekninger finnStrekningList = db.Strekninger.FirstOrDefault(s => s.StrekningsID == strekningsId);

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(finnStrekningList);
            }
        }
        public string hentReferanseNR()
        {
            using (var db = new DBContext())
            {
                int flyBestillingsId = db.FlyBestilling.Max(f => f.FlyBestillingsID);
                FlyBestilling finnRefNr = db.FlyBestilling.FirstOrDefault(f => f.FlyBestillingsID == flyBestillingsId);

                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(finnRefNr);
            }
        }
    }
}
