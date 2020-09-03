using System;

namespace air_ticket_cashier
{

    public class Flight
    {
        public int ID { get; set; }
        public DateTime DeparureAt { get; set; }
        public DateTime ArriveAt { get; set; }
        public bool Available { get; set; }
        public Direction Direction { get; set; }

    }

}