using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace air_ticket_cashier
{

    public class CashierContext : DbContext
    {

        public DbSet<Direction> Directions { get; set; }
        public DbSet<Flight> Flights { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Direction>().ToTable("");
            modelBuilder.Entity<Flight>().ToTable("Schedule");
        }
    }
}