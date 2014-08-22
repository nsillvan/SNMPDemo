using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SNMPDemo.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SNMPDemo.DAL
{
    public class SNMPDemoContext : DbContext
    {
        public SNMPDemoContext() :base("SNMPDemoContext")
        {
        }

        // DbSets
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}