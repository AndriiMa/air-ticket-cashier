using System.Linq;

namespace air_ticket_cashier
{

    public class TicketService
    {

        private CashierContext context;

        public TicketService(CashierContext cashierContext)
        {
            this.context = cashierContext;
        }

        public Ticket GetById(int id)
        {
            return context.Tickets.Where(t => t.ID == id)
            .FirstOrDefault();
        }

        public Ticket Save(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            return ticket;
        }

        public void Update(Ticket ticket)
        {
            context.Tickets.Update(ticket);
            context.SaveChanges();
        }

    }
}