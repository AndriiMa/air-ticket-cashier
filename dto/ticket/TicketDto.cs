namespace air_ticket_cashier
{
    public class TicketDto
    {
        public int ID { get; set; }
        public decimal Cost { get; set; }
        public int FlightId { get; set; }
        public int? PassengerId { get; set; }
        public int SeatNo { get; set; }
    }
}