using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace air_ticket_cashier
{
    [ApiController]
    [Route("/api/flights")]
    public class FlightController : ControllerBase
    {
        private FlightService flightService;

        public FlightController(FlightService flightService)
        {
            this.flightService = flightService;
        }

        [HttpGet("")]
        public List<Flight> GetAvailableFlights()
        {
            return flightService.GetAvailable();
        }

        [HttpGet("/{id}")]
        public Flight GetFlightById(int id)
        {
            return flightService.GetById(id);
        }

        [HttpGet("")]
        public List<Flight> GetFlightByDeparture(DepartureDto departureDto)
        {
            return flightService.GetByDeparture(departureDto.Departure);
        }
    }
}