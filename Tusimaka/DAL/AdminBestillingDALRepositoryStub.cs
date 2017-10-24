using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminBestillingDALRepositoryStub : DAL.IAdminBestillingRepository
    {
        public bool lagreFlyBestilling(FlyBestillinger innFlyinfo)
        {
            if (innFlyinfo.AntallPersoner == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool lagreKundeIdMotFlyBestilling(Kunde innKunde, FlyBestillinger innFlyinfo)
        {
            if(innKunde.KundeID == 0)
            {
                return false;
            }
            else
            {
                if (innFlyinfo.AntallPersoner == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public string hentAntallPersoner(int id)
        {
            if (id == 0)
            {
                var bestilling = new FlyBestillinger();
                bestilling.AntallPersoner = 0;
                return bestilling.AntallPersoner.ToString();
            }
            else
            {
                var bestilling = new FlyBestillinger()
                {
                    FlyBestillingsID = 1,
                    StrekningsID = 1,
                    AntallPersoner = 2,
                    ReturID = 3,
                };
                return bestilling.AntallPersoner.ToString();
            }
        }
        public string hentBestilling(int id)
        {
            if (id == 0)
            {
                var bestilling = new FlyBestillinger();
                bestilling.FlyBestillingsID = 0;
                return bestilling.ToString();
            }
            else
            {
                var bestilling = new FlyBestillinger()
                {
                    FlyBestillingsID = 1,
                    StrekningsID = 1,
                    AntallPersoner = 2,
                    ReturID = 3,
                };
                return bestilling.ToString();
            }
        }
        public string hentReferanseNR(int id)
        {
            if (id == 0)
            {
                var bestilling = new FlyBestillinger();
                bestilling.FlyBestillingsID = 0;
                return bestilling.FlyBestillingsID.ToString();
            }
            else
            {
                var bestilling = new FlyBestillinger()
                {
                    FlyBestillingsID = 1,
                    StrekningsID = 1,
                    AntallPersoner = 2,
                    ReturID = 3,
                };
                return bestilling.FlyBestillingsID.ToString();
            }
    }
