using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InvoiceSchemaMigration.Entities;

namespace InvoiceSchemaMigration
{
    class AppDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<Invoice> Invoice { get; set; }

        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=localhost;Database=AppDb;User Id=sa;Password=YOUR_strong_*pass4w0rd*");
        }
    }
}
