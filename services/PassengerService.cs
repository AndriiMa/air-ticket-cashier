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

        public void Update(Passenger passenger)
        {
            context.Passengers.Update(passenger);
            context.SaveChanges();
        }

        public void Delete(Passenger passenger)
        {
            context.Passengers.Remove(passenger);
            context.SaveChanges();
        }
    }
}