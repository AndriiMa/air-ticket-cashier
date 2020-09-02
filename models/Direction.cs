using System;

namespace air_ticket_cashier
{

    public class Direction
    {

        public int ID { get; set; }
        public String FromCountry { get; set; }
        public String ToCountry { get; set; }
        public bool Avaliable { get; set; }
        public int MaxPlaces { get; set; }
        public String PlaneCode { get; set; }
    }

}