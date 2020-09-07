using System;

namespace air_ticket_cashier
{
    public class TicketIsAlreadyBoughtException : Exception
    {
        public TicketIsAlreadyBoughtException(string message) : base(message) { }

    }
}