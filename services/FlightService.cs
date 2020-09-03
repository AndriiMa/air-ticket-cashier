using System;
using System.Collections.Generic;
using System.Linq;

namespace air_ticket_cashier
{

    public class FlightService
    {

        private CashierContext context;

        public FlightService(CashierContext context)
        {
            this.context = context;
        }

        public List<Flight> GetAvailable()
        {
            return context.Flights.Where(f => f.Avaliable == true)
            .ToList();
        }

        public Flight GetById(int id)
        {
            return context.Flights.Where(f => f.ID == id)
            .FirstOrDefault();
        }

        public List<Flight> GetByDepartureAt(DateTime departureAt)
        {
            return context.Flights.Where(f => f.DeparureAt.Equals(departureAt))
            .ToList();
        }
    }

}