using BikeRental.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeRental.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options ) : base(options) { }

        public DbSet<Bike> Bikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Bike>()
                .Property(e => e.Type)
                .HasConversion<string>();

            modelBuilder
                .Entity<Bike>()
                .Property(e => e.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Bike>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}
