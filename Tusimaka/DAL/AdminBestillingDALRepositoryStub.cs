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
        public List<KundeBestillinger> hentKundesFlyBestillinger(int id)
        {
            var kundeBestillingListe = new List<KundeBestillinger>();
            var bestilling = new KundeBestillinger()
            {
                KundeID = 1,
                Fornavn = "Helene",
                Etternavn = "Andersen",
                StrekningsID = 1,
                FraFlyplass = "Oslo",
                TilFlyplass = "Bergen",
                Dato = "2017-10-20",
                Pris = 1234,
                Tid = "12:30",
                AntallPersoner = 4

            };
            
            kundeBestillingListe.Add(bestilling);
            kundeBestillingListe.Add(bestilling);
            kundeBestillingListe.Add(bestilling);
            return kundeBestillingListe;
        }
        public bool lagreBetalingsinformasjon(int id, BetalingsInformasjon innBetaling)
        {
            if(innBetaling.BestillingsID == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool LagreAdminFlyBestilling(int id, FlyBestillinger nyBestilling)
        {
            if (nyBestilling.FlyBestillingsID == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool SlettKundeBestilling(int id)
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
    }
}
