using System.Collections.Generic;

namespace air_ticket_cashier
{
    public class FlightMapper
    {

        public FlightDto MapToDto(Flight flight)
        {
            FlightDto dto = new FlightDto();

            dto.ID = flight.ID;
            dto.ArriveAt = flight.ArriveAt;
            dto.DepartureAt = flight.DepartureAt;
            dto.Avaliable = flight.Avaliable;
            dto.DirectionId = flight.Direction.ID;

            return dto;
        }

        public Flight MapToObject(FlightDto dto)
        {
            Flight flight = new Flight();

            flight.ID = dto.ID;
            flight.ArriveAt = dto.ArriveAt;
            flight.DepartureAt = dto.DepartureAt;
            flight.Avaliable = dto.Avaliable;

            return flight;
        }

        public List<FlightDto> MapToList(List<Flight> flights)
        {
            List<FlightDto> dtos = new List<FlightDto>();

            foreach (Flight flight in flights)
            {
                dtos.Add(MapToDto(flight));
            }
            return dtos;
        }

    }
}