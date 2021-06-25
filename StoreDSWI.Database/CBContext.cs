using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.Entity;
using StoreDSWI.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StoreDSWI.Database
{
    public class CBContext : IdentityDbContext<StoreDSWIUser>
    {
        public CBContext() : base("StoreDSWIConnection")
        {
            System.Data.Entity.Database.SetInitializer<CBContext>(new StoreDSWIDBInitializer());
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Config> Configurations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public static CBContext Create()
        {
            return new CBContext();
        }
        
    }
}
