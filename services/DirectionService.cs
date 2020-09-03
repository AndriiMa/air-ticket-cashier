using System.Collections.Generic;
using System.Linq;

namespace air_ticket_cashier
{
    public class DirectionService
    {
        private CashierContext context;

        public DirectionService(CashierContext cashierContext)
        {
            this.context = cashierContext;
        }

        public Direction GetById(int id)
        {

            Direction direction = null;
            direction = context.Directions
                                 .Where(s => s.ID == id)
                                 .FirstOrDefault<Direction>();
            return direction;
        }

        public List<Direction> GetAvailable()
        {
            List<Direction> directions = null;
            directions = context.Directions
                                 .Where(s => s.Avaliable == true)
                                 .ToList();
            return directions;
        }
    }
}