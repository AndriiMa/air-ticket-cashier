using System;

namespace air_ticket_cashier
{

    public class Flight
    {
        public int id { get; set; }
        public DateTime deparureAt { get; set; }
        public DateTime arriveAt { get; set; }
        public bool available { get; set; }

    }

}