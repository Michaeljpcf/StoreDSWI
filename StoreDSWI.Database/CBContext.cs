using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Data.Entity;
using StoreDSWI.Entities;

namespace StoreDSWI.Database
{
    public class CBContext : DbContext, IDisposable
    {
        public CBContext() : base("StoreDSWIConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Config> Configurations { get; set; }
    }
}
