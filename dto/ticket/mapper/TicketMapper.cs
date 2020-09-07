using System.Collections.Generic;

namespace air_ticket_cashier
{
    public class TicketMapper
    {

        public Ticket mapToObject(TicketDto dto)
        {
            Ticket ticket = new Ticket();
            ticket.Cost = dto.Cost;
            ticket.ID = dto.ID;
            ticket.SeatNo = dto.SeatNo;

            return ticket;
        }

        public TicketDto mapToDto(Ticket ticket)
        {
            TicketDto dto = new TicketDto();
            dto.ID = ticket.ID;
            dto.Cost = ticket.Cost;
            if (ticket.passenger != null)
            {
                dto.PassengerId = ticket.passenger.ID;
            }
            dto.FlightId = ticket.flight.ID;
            dto.SeatNo = ticket.SeatNo;

            return dto;
        }

        public List<TicketDto> mapToList(List<Ticket> tickets)
        {
            List<TicketDto> dtos = new List<TicketDto>();

            foreach (Ticket ticket in tickets)
            {
                dtos.Add(mapToDto(ticket));
            }

            return dtos;
        }

    }
}