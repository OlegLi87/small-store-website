using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySmallStore.Models;

namespace MySmallStore.DAL
{
    public class StoreContext :DbContext
    {
        public StoreContext() : base("SmallStoreDataBase")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }      
        public DbSet<Order> Orders { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}