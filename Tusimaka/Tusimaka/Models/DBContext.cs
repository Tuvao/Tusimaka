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
            public DbSet<strekning> Strekning { get; set; }
            
            public DbSet<Kunde> Kunder { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        

        }
}