using System;

namespace air_ticket_cashier
{
    public class FlightDto
    {
        public int ID { get; set; }
        public DateTime DepartureAt { get; set; }
        public DateTime ArriveAt { get; set; }
        public bool Avaliable { get; set; }
        public int DirectionId { get; set; }
    }
}