using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace air_ticket_cashier
{
    [ApiController]
    [Route("api/flights")]
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

        [HttpGet("{id}")]
        public Flight GetFlightById(int id)
        {
            return flightService.GetById(id);
        }

        [HttpGet("")]
        public List<Flight> GetFlightByDeparture([FromBody] FlightDepartureDto flightDepartureDto)
        {
            return flightService.GetByDeparture(flightDepartureDto);
        }

        [HttpPost("")]
        public Flight CreateFlight([FromBody] Flight flight)
        {
            return flightService.SaveFlight(flight);
        }

        [HttpPatch("{id}")]
        public void SetAvailabilityById(int id, [FromBody] AvailabilityDto dto)
        {
            flightService.SetAvailabilityById(id, dto.Available);
        }

    }
}