﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class FlyDAL
    {
        public string hentAlleFraFlyplasser()
        {
            using (var db = new DBContext())
            {
                try
                {
                    List<Strekninger> alleFly = db.Strekninger.ToList();

                    var alleFraFly = new List<string>();

                    foreach (Strekninger f in alleFly)
                    {
                        string funnetStrekning = alleFraFly.FirstOrDefault(fl => fl.Contains(f.fraFlyplass));
                        if (funnetStrekning == null)
                        {
                            // ikke funnet strekning i listen, legg den inn i listen
                            alleFraFly.Add(f.fraFlyplass);
                        }
                    }
                    var jsonSerializer = new JavaScriptSerializer();
                    return jsonSerializer.Serialize(alleFraFly);
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

        public string hentTilFlyplasser(string fraFlyPlass)
        {
            using (var db = new DBContext())
            {
                try
                {
                    List<Strekninger> alleFly = db.Strekninger.ToList();

                    var alleTilFly = new List<string>();

                    foreach (Strekninger f in alleFly)
                    {
                        if (f.fraFlyplass == fraFlyPlass)
                        {
                            string funnetStrekning = alleTilFly.FirstOrDefault(fl => fl.Contains(f.tilFlyplass));
                            if (funnetStrekning == null)
                            {
                                // ikke funnet strekning i listen, legg den inn i listen
                                alleTilFly.Add(f.tilFlyplass);
                            }
                        }
                    }
                    var jsonSerializer = new JavaScriptSerializer();
                    return jsonSerializer.Serialize(alleTilFly);
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
        public string hentStrekning(string fraFlyplass, string tilFlyPlass, string dato, int antallLedigeSeter)
        {
            using (var db = new DBContext())
            {
                try
                {
                    List<Strekninger> alleFly = db.Strekninger.Where(
                        f => f.tilFlyplass == tilFlyPlass && f.fraFlyplass == fraFlyplass && f.dato == dato && f.antallLedigeSeter >= antallLedigeSeter).ToList();

                    var jsonSerializer = new JavaScriptSerializer();
                    return jsonSerializer.Serialize(alleFly);
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

        public string hentRetur()
        {
            using (var db = new DBContext())
            {
                try
                {
                    int flyBestillingsId = db.FlyBestilling.Max(f => f.FlyBestillingsID);
                    FlyBestilling finnRetur = db.FlyBestilling.FirstOrDefault(f => f.FlyBestillingsID == flyBestillingsId);
                    Strekninger finnReturList = new Strekninger();
                    if (finnRetur.ReturID != null)
                    {
                        int? returId = finnRetur.ReturID;
                        finnReturList = db.Strekninger.FirstOrDefault(r => r.StrekningsID == returId);
                    }

                    var jsonSerializer = new JavaScriptSerializer();
                    return jsonSerializer.Serialize(finnReturList);
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
}
