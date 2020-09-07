using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace air_ticket_cashier.controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketController : ControllerBase
    {

        private TicketService ticketService;
        private PassengerService passengerService;

        public TicketController(TicketService ticketService, PassengerService passengerService)
        {
            this.ticketService = ticketService;
            this.passengerService = passengerService;
        }

        [HttpGet("{id}")]
        public Ticket GetTicketById(int id)
        {
            return ticketService.GetById(id);
        }

        [HttpPost("")]
        public Ticket CreateTicket([FromBody] Ticket ticket)
        {
            return ticketService.Save(ticket);
        }

        [HttpPost("{id}/buy")]
        public Ticket BuyTicket(int id, [FromBody] PassengerIdDto passengerId)
        {
            Passenger passenger = passengerService.GetById(id);
            return ticketService.BuyTicketWithId(id, passenger);
        }

        [HttpPost("buy-couple")]
        public List<Ticket> ButTicketsByIds([FromBody] PassengerWithTicketsIdsDto dto)
        {
            Passenger passenger = passengerService.GetById(dto.PassengerId);
            return ticketService.BuyTicketsByIds(dto.Ids, passenger);
        }
    }
}