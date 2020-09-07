namespace air_ticket_cashier
{

    public class Ticket
    {
        public int ID { get; set; }
        public decimal Cost { get; set; }
        public Flight flight { get; set; }
        public int SeatNo { get; set; }
        public Passenger passenger { get; set; }
    }

}