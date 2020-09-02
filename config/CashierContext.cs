using Microsoft.EntityFrameworkCore;

namespace air_ticket_cashier
{

    public class CashierContext : DbContext
    {

        public DbSet<Direction> Directions { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public CashierContext(DbContextOptions<CashierContext> options)
            : base(options)
        {
        }
    }
}