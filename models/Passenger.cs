using System;

namespace air_ticket_cashier
{
    public class Passenger
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PassportNo { get; set; }
        public String CountryCode { get; set; }
        public String Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public PassengerSex PassengerSex { get; set; }

    }
}