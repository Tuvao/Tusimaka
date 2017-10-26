using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Tusimaka.Model;

namespace Tusimaka.DAL
{
    public class Kunder
    {
        [Key]
        public int KundeID { get; set; }
        public string fornavn { get; set; }
        public string etternavn { get; set; }
        public string epost { get; set; }
        public string kjonn { get; set; }
    }
    public class FlyBestilling
    {
        [Key]
        public int FlyBestillingsID { get; set; }
        public int StrekningsID { get; set; }
        public int antallPersoner { get; set; }
        public int? ReturID { get; set; }
        
        public virtual Strekninger Strekninger { get; set; }
    }
    public class Strekninger
    {
        [Key]
        public int StrekningsID { get; set; }
        public string fraFlyplass { get; set; }
        public string tilFlyplass { get; set; }
        public string dato { get; set; }
        public string tid { get; set; }
        public int pris { get; set; }
        public double flyTid { get; set; }
        public int antallLedigeSeter { get; set; }
    }

    //Hjelpetabell for å kunne registrere kundeid til flybestillingsordre i etterkant. 
    public class FlyBestillingKunder
    {
        [Key]
        public int flyBestillingsKundeID { get; set; }
        public int FlyBestillingsID { get; set; }
        public int KundeID { get; set; }

        public virtual Kunder Kunder { get; set; }
        public virtual FlyBestilling FlyBestilling { get; set; }
    }

    public class BetalingsInfo
    {
        [Key]
        public int BestillingsID { get; set; }
        public int FlyBestillingsID { get; set; }
        public string Kortnummer { get; set; }
        public string Utlopsmnd { get; set; }
        public string Utlopsaar { get; set; }
        public string CVC { get; set; }
        public string Korttype { get; set; }

        public virtual FlyBestilling FlyBestilling { get; set; }
    }
    public class AdminBrukere
    {
        [Key]
        public string brukernavn { get; set; }
        public byte[] passord { get; set; }
    }

    //kopiert fra link, se readme.txt
    public class ChangeLog
    {
        public int Id { get; set; }
        public string EntityName { get; set; }
        public string PropertyName { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime DateChanged { get; set; }
    }

    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=Fly")
        {
            Database.CreateIfNotExists();

            Database.SetInitializer(new DBInit());
        }
        //metode kopiert fra link, se readme.txt
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual DbSet<Strekninger> Strekninger { get; set; }
        public virtual DbSet<Kunder> Kunder { get; set; }
        public virtual DbSet<FlyBestilling> FlyBestilling { get; set; }
        public virtual DbSet<BetalingsInfo> BetalingsInfo{ get; set; }
        public virtual DbSet<FlyBestillingKunder> FlyBestillingKunder { get; set; }
        public virtual DbSet<AdminBrukere> AdminBrukere { get; set; }
        public virtual DbSet<ChangeLog> ChangeLogs { get; set; }


        //kode kopiert fra link, se readme.txt   
        public override int SaveChanges()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified).ToList();
            var now = DateTime.UtcNow;

            foreach (var change in modifiedEntities)
            {
                var entityName = change.Entity.GetType().Name;
                var primaryKey = GetPrimaryKeyValue(change);
                
                foreach (var prop in change.OriginalValues.PropertyNames)
                {
                    var originalValue = change.OriginalValues[prop].ToString();
                    var currentValue = change.CurrentValues[prop].ToString();
                    //Sjekker om det har vært endringer
                    if (originalValue != currentValue)
                    {
                        ChangeLog log = new ChangeLog()
                        {
                            EntityName = entityName,
                            PrimaryKeyValue = primaryKey.ToString(),
                            PropertyName = prop,
                            OldValue = originalValue,
                            NewValue = currentValue,
                            DateChanged = now
                        };
                        ChangeLogs.Add(log);
                    }
                }
            }
            return base.SaveChanges();
        }
        


        object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
    }
}