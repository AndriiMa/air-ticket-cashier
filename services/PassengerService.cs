using System.Linq;

namespace air_ticket_cashier
{

    public class PassengerService
    {

        private CashierContext context;

        public PassengerService(CashierContext cashierContext)
        {
            this.context = cashierContext;
        }

        public Passenger GetById(int id)
        {
            return context.Passengers.Where(p => p.ID == id)
            .FirstOrDefault();
        }

        public Passenger Save(Passenger passenger)
        {
            context.Passengers.Add(passenger);
            return passenger;
        }

        public void Update(Passenger passengerUpdates)
        {
            Passenger passenger = context.Passengers.FirstOrDefault(p => p.ID == passengerUpdates.ID);
            passenger.FirstName = passengerUpdates.LastName;
            passenger.LastName = passengerUpdates.LastName;
            passenger.PassengerSex = passengerUpdates.PassengerSex;
            

            context.Passengers.Update(passenger);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Passenger passenger = context.Passengers.FirstOrDefault(p => p.ID == id);

            context.Passengers.Remove(passenger);
            context.SaveChanges();
        }
    }
}