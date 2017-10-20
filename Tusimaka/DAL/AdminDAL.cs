﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminDAL
    {
        public bool Bruker_i_DB(AdminBruker innAdminBruker)
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
