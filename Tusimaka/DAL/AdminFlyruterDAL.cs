﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminFlyruterDAL : DAL.IAdminFlyruterRepository
    {
        public List<Strekning> hentAlleFlyruter()
        {
            using (var db = new DBContext())
            {
                try
                {
                    List<Strekning> alleStrekninger = db.Strekninger.Select(s => new Strekning()
                    {
                        StrekningsID = s.StrekningsID,
                        TilFlyplass = s.tilFlyplass,
                        FraFlyplass = s.fraFlyplass,
                        Dato = s.dato,
                        Tid = s.tid,
                        Pris = s.pris,
                        FlyTid = s.flyTid,
                        AntallLedigeSeter = s.antallLedigeSeter
                    }).ToList();
                    return alleStrekninger;
                }
                catch (Exception feil)
                {
                    string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return null;
                }
            }
        }
        public bool lagreFlyrute(Strekning innFlyrute)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var nyFlyruter = new Strekninger();
                    nyFlyruter.tilFlyplass = innFlyrute.TilFlyplass;
                    nyFlyruter.fraFlyplass = innFlyrute.FraFlyplass;
                    nyFlyruter.dato = innFlyrute.Dato;
                    nyFlyruter.tid = innFlyrute.Tid;
                    nyFlyruter.pris = innFlyrute.Pris;
                    nyFlyruter.flyTid = innFlyrute.FlyTid;
                    nyFlyruter.antallLedigeSeter = innFlyrute.AntallLedigeSeter;

                    db.Strekninger.Add(nyFlyruter);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return false;
                }
            }
        }

        public bool slettFlyrute(int id)
        {
            var db = new DBContext();
            try
            {
                Strekninger slettFlyrute = db.Strekninger.Find(id);
                db.Strekninger.Remove(slettFlyrute);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                string text = feil.ToString();
                File.AppendAllText(path, text);
                return false;
            }
        }
        public bool endreFlyrute(int id, Strekning innFlyrute)
        {
            var db = new DBContext();
            try
            {
                Strekninger endreFlyrute = db.Strekninger.Find(id);
                endreFlyrute.fraFlyplass = innFlyrute.FraFlyplass;
                endreFlyrute.tilFlyplass = innFlyrute.TilFlyplass;
                endreFlyrute.dato = innFlyrute.Dato;
                endreFlyrute.tid = innFlyrute.Tid;
                endreFlyrute.pris = innFlyrute.Pris;
                endreFlyrute.flyTid = innFlyrute.FlyTid;
                endreFlyrute.antallLedigeSeter = innFlyrute.AntallLedigeSeter;
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                string text = feil.ToString();
                File.AppendAllText(path, text);
                return false;
            }
        }
        public Strekning hentDenneFlyruten(int id)
        {
            var db = new DBContext();
            try { 
                var denneFlyruten = db.Strekninger.Find(id);

                if (denneFlyruten == null)
                {
                    return null;
                }
                else
                {
                    var utFlyrute = new Strekning()
                    {
                        StrekningsID = denneFlyruten.StrekningsID,
                        FraFlyplass = denneFlyruten.fraFlyplass,
                        TilFlyplass = denneFlyruten.tilFlyplass,
                        Dato = denneFlyruten.dato,
                        Tid = denneFlyruten.tid,
                        Pris = denneFlyruten.pris,
                        FlyTid = denneFlyruten.flyTid,
                        AntallLedigeSeter = denneFlyruten.antallLedigeSeter
                    };
                    return utFlyrute;
                }
            }
            catch (Exception feil)
            {
                string path = HttpContext.Current.Server.MapPath("~/logg.txt");
                string text = feil.ToString();
                File.AppendAllText(path, text);
                return null;
            }
        }
    }
}
