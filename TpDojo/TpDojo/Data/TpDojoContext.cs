using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TpDojo.Data
{
    public class TpDojoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TpDojoContext() : base("name=TpDojoContext")
        {
        }

        public System.Data.Entity.DbSet<BO.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<BO.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<BO.ArtMartial> ArtMartials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Une Arme appartient à un seul samourai
            modelBuilder.Entity<Samourai>().HasOptional(x => x.Arme);

            //Un art martial peut être associé à un ou plusieurs samourais
            //modelBuilder.Entity<Samourai>().HasOptional(x => x.ArtMartiaux).WithMany();

        }
    }
}
