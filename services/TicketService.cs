using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return context.Tickets
            .Include(ticket => ticket.flight)
            .Include(ticket => ticket.passenger)
            .Where(t => t.ID == id)
            .FirstOrDefault();
        }

        public Ticket Save(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            context.SaveChanges();
            return ticket;
        }

        public List<Int32> SaveByFlightAndCost(int cost, Flight flight)
        {
            List<Ticket> tickets = CreateTicketsWithFlightAndCost(cost, flight);
            foreach (Ticket ticket in tickets)
            {
                context.Tickets.Add(ticket);
            }
            context.SaveChanges();
            return GetIDsFromTickets(tickets);
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

        private List<Int32> GetIDsFromTickets(List<Ticket> tickets)
        {
            List<Int32> ticketsIDs = new List<Int32>();
            foreach (Ticket ticket in tickets)
            {
                ticketsIDs.Add(ticket.ID);
            }

            return ticketsIDs;
        }

        private List<Ticket> CreateTicketsWithFlightAndCost(int cost, Flight flight)
        {
            List<Ticket> tickets = new List<Ticket>();
            if (context.Tickets.Any(p => p.flight.ID == flight.ID))
            {
                throw new TicketsIsCreatedException("Tickets for this flight is already created!");
            }
            else
            {
                int seats = flight.Direction.MaxSeats;

                for (int i = 1; i <= seats; i++)
                {
                    tickets.Add(CreateTicket(i, cost, flight));
                }
            }
            return tickets;
        }

        private Ticket CreateTicket(int seatNo, int cost, Flight flight)
        {
            Ticket ticket = new Ticket();
            ticket.Cost = cost;
            ticket.SeatNo = seatNo;
            ticket.flight = flight;

            return ticket;
        }
    }
}