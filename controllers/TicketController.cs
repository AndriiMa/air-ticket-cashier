using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace air_ticket_cashier.controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketController : ControllerBase
    {

        private TicketService ticketService;
        private FlightService flightService;
        private PassengerService passengerService;
        private TicketMapper ticketMapper;

        public TicketController(TicketService ticketService,
         PassengerService passengerService,
          FlightService flightService)
        {
            this.ticketService = ticketService;
            this.passengerService = passengerService;
            this.flightService = flightService;
            this.ticketMapper = new TicketMapper();
        }

        [HttpGet("{id}")]
        public TicketDto GetTicketById(int id)
        {
            Ticket ticket = ticketService.GetById(id);

            return ticketMapper.mapToDto(ticket);
        }

        // [HttpPost("")]
        // public TicketDto CreateTicket([FromBody] TicketDto ticketDto)
        // {
        //     Ticket ticket = Create(ticketDto);
        //     Ticket savedTicket = ticketService.Save(ticket);
        //     return ticketMapper.mapToDto(savedTicket);
        // }

        [HttpPost]
        public List<Int32> CreateTicketsByFlightAndCost(TicketsCreationDto dto)
        {
            Flight flight = flightService.GetById(dto.FlightId);
            List<Int32> ids = ticketService.SaveByFlightAndCost(dto.Cost, flight);
            return ids;
        }

        [HttpPost("{id}/buy")]
        public TicketDto BuyTicket(int id, [FromBody] PassengerIdDto passengerId)
        {
            Passenger passenger = passengerService.GetById(id);
            Ticket ticket = ticketService.BuyTicketWithId(id, passenger);

            return ticketMapper.mapToDto(ticket);
        }

        [HttpPost("buy-couple")]
        public List<TicketDto> ButTicketsByIds([FromBody] PassengerWithTicketsIdsDto dto)
        {
            Passenger passenger = passengerService.GetById(dto.PassengerId);
            List<Ticket> tickets = ticketService.BuyTicketsByIds(dto.Ids, passenger);
            return ticketMapper.mapToList(tickets);
        }

        private Ticket Create(TicketDto dto)
        {
            Flight flight = flightService.GetById(dto.FlightId);

            Ticket ticket = ticketMapper.mapToObject(dto);
            ticket.flight = flight;

            return ticket;

        }
    }
}