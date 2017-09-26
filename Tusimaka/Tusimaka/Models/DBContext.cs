using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Tusimaka.Models
{
    
        public class strekning
        {
            public int id { get; set; }
            public string fraFlyplass { get; set; }
            public string tilFlyplass { get; set; }
            public string dato { get; set; }
            public string tid { get; set; }
            public string pris { get; set; }
        }


        public class DBContext : DbContext
        {
            public DBContext()
              : base("name=Fly")
            {
                Database.CreateIfNotExists();

                Database.SetInitializer(new DBInit());
            }
            public DbSet<strekning> Strekning { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }
    
}