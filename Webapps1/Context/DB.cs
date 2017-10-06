using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Webapps1.Context;
using Webapps1.Models;

namespace Webapps1
{
    public class DB : DbContext
    {
         
        public DB() : base("name=BillettReservasjoner")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Flyplass> Flyplasser { get; set; }
        public virtual DbSet<Rute> Ruter { get; set; }
        public virtual DbSet<Billett> Billetter { get; set; }
        public virtual DbSet<Reservasjon> Reservasjoner { get; set; }


    }
}