using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Tusimaka.Models
{
    public class Kunder
    {
        [Key]
        public int kundeID { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string kjonn { get; set; }

        //public virtual List<FlyBestillinger> FlyBestillinger { get; set; }
    }
    public class FlyBestilling
    {
        [Key]
        public int flyBestillingsID { get; set; }
        //public int kundeID { get; set; }
        public int StrekningsID { get; set; }
        public int antallPersoner { get; set; }
        public int? returID { get; set; }

        //public virtual Kunde Kunde { get; set; }
        
        public virtual strekning Strekning { get; set; }
    }
    //Hjelpetabell for å kunne registrere kundeid til flybestillingsordre i etterkant. 
    public class FlyBestillingKunder
    {
        [Key]
        public int flyBestillingsKundeID { get; set; }
        public int flyBestillingsID { get; set; }
        public int kundeID { get; set; }

        public virtual Kunder Kunder { get; set; }
        public virtual FlyBestilling FlyBestilling { get; set; }
    }
    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=Fly")
        {
            Database.CreateIfNotExists();

            Database.SetInitializer(new DBInit());
        }
        public virtual DbSet<strekning> Strekning { get; set; }
        public virtual DbSet<Kunder> Kunder { get; set; }
        public virtual DbSet<FlyBestilling> FlyBestilling { get; set; }
        public virtual DbSet<BetalingsInformasjon> BetalingsInformasjon { get; set; }
        public virtual DbSet<FlyBestillingKunde> FlyBestillingKunde { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        

    }
}