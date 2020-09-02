using System.Collections.Generic;
using System.Linq;

namespace air_ticket_cashier
{
    public class DirectionService
    {
        public Direction GetById(int id)
        {
            Direction direction = null;
            using (var context = new CashierContext())
            {
                direction = context.Directions
                                     .Where(s => s.ID == id)
                                     .FirstOrDefault<Direction>();
                return direction;
            }
        }

        public List<Direction> GetAvailable()
        {
            List<Direction> directions = null;
            using (var context = new CashierContext())
            {
                directions = context.Directions
                                     .Where(s => s.Avaliable == true)
                                     .ToList();
                return directions;
            }
        }
    }
}