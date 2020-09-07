using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace air_ticket_cashier
{

    public class CashierContext : DbContext
    {
        public CashierContext(DbContextOptions<CashierContext> options) : base(options)
        {
        }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<DirectionType>();
            modelBuilder.HasPostgresEnum<PassengerSex>();

            modelBuilder.UseSerialColumns();

            modelBuilder.Entity<Direction>().ToTable("direction");
            modelBuilder.Entity<Flight>().ToTable("flight");
            modelBuilder.Entity<Passenger>().ToTable("passenger");
            modelBuilder.Entity<Ticket>().ToTable("ticket");

        }

    }
}