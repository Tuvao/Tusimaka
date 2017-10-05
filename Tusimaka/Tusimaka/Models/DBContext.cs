using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Tusimaka.Models
{
        public class DBContext : DbContext
        {
            public DBContext()
              : base("name=Fly")
            {
                Database.CreateIfNotExists();

                Database.SetInitializer(new DBInit());
            }
            public virtual DbSet<strekning> Strekning { get; set; }
            
            public virtual DbSet<Kunde> Kunder { get; set; }
            public virtual DbSet<FlyBestillinger> FlyBestillinger { get; set; }
            public virtual DbSet<KomplettReise> KomplettReise { get; set; }

            public virtual DbSet<BetalingsInformasjon> BetalingsInformasjon { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        

        }
}