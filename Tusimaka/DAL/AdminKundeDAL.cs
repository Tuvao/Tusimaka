using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class AdminKundeDAL : DAL.IAdminKundeRepository
    {
        public List<Kunde> hentAlleKunder()
        {
            using (var db = new DBContext())
            {
                try
                {
                    List<Kunde> alleKunder = db.Kunder.Select(k => new Kunde()
                    {
                        KundeID = k.KundeID,
                        Fornavn = k.fornavn,
                        Etternavn = k.etternavn,
                        Epost = k.epost,
                        Kjonn = k.kjonn
                    }).ToList();
                    return alleKunder;
                }
                catch (Exception feil)
                {
                    string path = @"C:\Users\Bruker\source\repos\Tusimaka\logg.txt";
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return null;
                }
            }
        }
        public bool slettKunde(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Kunder slettKunde = db.Kunder.Find(id);
                    db.Kunder.Remove(slettKunde);
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
        public bool endreKunde(int id, Kunde innKunde)
        {
            using (var db = new DBContext())
            {
                try
                {
                    Kunder endreKunde = db.Kunder.Find(id);
                    endreKunde.fornavn = innKunde.Fornavn;
                    endreKunde.etternavn = innKunde.Etternavn;
                    endreKunde.epost = innKunde.Epost;
                    endreKunde.kjonn = innKunde.Kjonn;
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
        public Kunde hentDenneKunden(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var denneKunden = db.Kunder.Find(id);

                    if (denneKunden == null)
                    {
                        return null;
                    }
                    else
                    {
                        var utKunde = new Kunde()
                        {
                            KundeID = denneKunden.KundeID,
                            Fornavn = denneKunden.fornavn,
                            Etternavn = denneKunden.etternavn,
                            Epost = denneKunden.epost,
                            Kjonn = denneKunden.kjonn
                        };
                        return utKunde;
                    }
                }
                catch (Exception feil)
                {
                    string path = @"C:\Users\Bruker\source\repos\Tusimaka\logg.txt";
                    string text = feil.ToString();
                    File.AppendAllText(path, text);
                    return null;
                }

            }
        }
    }
}
