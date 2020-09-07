using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace air_ticket_cashier
{
    [ApiController]
    [Route("api/flights")]
    public class FlightController : ControllerBase
    {
        private FlightService flightService;
        private DirectionService directionService;
        private FlightMapper flightMapper;

        public FlightController(FlightService flightService, DirectionService directionService)
        {
            this.flightService = flightService;
            this.directionService = directionService;
            this.flightMapper = new FlightMapper();
        }

        [HttpGet("")]
        public List<FlightDto> GetAvailableFlights()
        {
            List<Flight> flights = flightService.GetAvailable();
            return flightMapper.MapToList(flights);
        }

        [HttpGet("{id}")]
        public FlightDto GetFlightById(int id)
        {
            Flight flight = flightService.GetById(id);
            return flightMapper.MapToDto(flight);
        }

        [HttpGet("by-departure")]
        public List<FlightDto> GetFlightByDeparture([FromBody] FlightDepartureDto flightDepartureDto)
        {
            List<Flight> flights = flightService.GetByDeparture(flightDepartureDto);
            return flightMapper.MapToList(flights);
        }

        [HttpPost("")]
        public FlightDto CreateFlight([FromBody] FlightDto dto)
        {
            Flight flight = Create(dto);
            Flight savedFlight = flightService.SaveFlight(flight);
            return flightMapper.MapToDto(savedFlight);
        }

        [HttpPatch("{id}")]
        public void SetAvailabilityById(int id, [FromBody] AvailabilityDto dto)
        {
            flightService.SetAvailabilityById(id, dto.Available);
        }

        [HttpGet("by-period")]
        public List<FlightDto> GetFlightsInPeriod([FromBody] FlightDatesDto dto)
        {
            List<Flight> flights = flightService.GetAllInPeriod(dto.FromDate, dto.ToDate);
            return flightMapper.MapToList(flights);
        }

        private Flight Create(FlightDto dto)
        {
            Direction direction = directionService.GetById(dto.DirectionId);
            Flight flight = flightMapper.MapToObject(dto);
            flight.Direction = direction;

            return flight;
        }

    }
}