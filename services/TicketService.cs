using System;
using System.Collections.Generic;
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
            context.SaveChanges();
            return ticket;
        }

        public void Update(Ticket ticket)
        {
            context.Tickets.Update(ticket);
            context.SaveChanges();
        }

        public Ticket BuyTicketWithId(int ID, Passenger passenger)
        {
            Ticket ticket = GetById(ID);
            if (ticket.passenger == null && ticket.flight.Avaliable == true)
            {
                ticket.passenger = passenger;
                Update(ticket);
                return ticket;
            }
            else
            {
                throw new TicketIsAlreadyBoughtException("Sorry but ticket is already bought or not available");
            }

        }

        public List<Ticket> BuyTicketsByIds(IEnumerable<Int32> ids, Passenger passenger)
        {
            List<Ticket> tickets = new List<Ticket>();
            foreach (int id in ids)
            {
                tickets.Add(BuyTicketWithId(id, passenger));
            }
            return tickets;
        }
    }
}