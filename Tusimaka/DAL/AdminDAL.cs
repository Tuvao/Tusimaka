using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminDAL
    {
        //public bool registrerAdminBruker()
        //{
        //    using(var db = new DBContext())
        //    {
        //        try
        //        {
        //            string sattBrukernavn = "Admin";
        //            string sattPassord = "Bord321";
        //            var nyAdminBruker = new AdminBrukere();
        //            byte[] hashetPassord = lagHash(sattPassord);
        //            nyAdminBruker.passord = hashetPassord;
        //            nyAdminBruker.brukernavn = sattBrukernavn;
        //            db.AdminBrukere.Add(nyAdminBruker);
        //            db.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception feil)
        //        {
        //            return false;
        //        }
        //    }
        //}
        public bool BrukerIDB(AdminBruker innAdminBruker)
        {
            using (var db = new DBContext())
            {
                byte[] passordDb = lagHash(innAdminBruker.Passord);
                AdminBrukere funnetAdminBruker = db.AdminBrukere.FirstOrDefault
                (b => b.passord == passordDb && b.brukernavn == innAdminBruker.Brukernavn);
                if (funnetAdminBruker == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
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
