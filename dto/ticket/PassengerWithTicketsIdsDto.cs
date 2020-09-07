using System;
using System.Collections.Generic;

namespace air_ticket_cashier.controllers
{
    public class PassengerWithTicketsIdsDto
    {
        public IEnumerable<Int32> Ids { get; set; }

        public int PassengerId { get; set; }

    }
}