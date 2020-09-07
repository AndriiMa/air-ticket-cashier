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

        public List<Flight> GetAllInPeriod(DateTime from, DateTime to)
        {
            if (from <= DateTime.Now || from == null)
            {
                from = DateTime.Now;
            }

            if (to <= DateTime.Now || to == null)
            {
                to = DateTime.Now;
            }

            return context.Flights.Where(f =>
             from >= f.DepartureAt && f.DepartureAt <= to)
             .ToList();
        }

        public List<Flight> GetByDeparture(FlightDepartureDto departureAt)
        {
            return context.Flights.Where(f => f.DepartureAt.Equals(departureAt))
            .ToList();
        }

        public Flight SaveFlight(Flight flight)
        {
            context.Flights.Add(flight);
            context.SaveChanges();
            return flight;
        }

        public void SetAvailabilityById(int id, bool avaliable)
        {
            Flight flight = GetById(id);
            flight.Avaliable = avaliable;

            context.Flights.Update(flight);
            context.SaveChanges();
        }

    }

}