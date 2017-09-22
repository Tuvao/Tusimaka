using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Tusimaka.Models
{
    public class DB : DbContext
    {
        public DB()
           : base("name=Bestilling") //navnet til connection strengen til databasen. 
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Bestilling> Bestillinger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //må ha hvis vi progr på norsk og har norske navn. For å unngå s(flertall) bak tabellnavnet. 
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}