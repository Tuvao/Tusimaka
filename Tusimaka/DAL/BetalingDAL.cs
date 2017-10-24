using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.DAL;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
     public class BetalingDAL
    {
        public bool lagreBetalingsinformasjon(BetalingsInformasjon innBetaling)
        {
            using (var db = new DBContext())
            {
                try
                {
                    int flyBestillingsId = db.FlyBestilling.Max(f => f.FlyBestillingsID);

                    var nyBetaling = new BetalingsInfo();
                    nyBetaling.FlyBestillingsID = flyBestillingsId;
                    nyBetaling.Kortnummer = innBetaling.Kortnummer;
                    nyBetaling.Utlopsmnd = innBetaling.Utlopsmnd;
                    nyBetaling.Utlopsaar = innBetaling.Utlopsaar;
                    nyBetaling.Utlopsmnd = innBetaling.Utlopsmnd;
                    nyBetaling.CVC = innBetaling.CVC;
                    nyBetaling.Korttype = innBetaling.Korttype;

                    db.BetalingsInfo.Add(nyBetaling);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    string path = @"C:\Users\Bruker\source\repos\Tusimaka\logg.txt";
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return false;
                }
            }
        }
    }
}
