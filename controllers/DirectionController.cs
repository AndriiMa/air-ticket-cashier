using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace air_ticket_cashier
{

    [ApiController]
    [Route("api/directions")]
    public class DirecionController : ControllerBase
    {

        private DirectionService directionService;
        public DirecionController(DirectionService directionService)
        {
            this.directionService = directionService;
        }

        [HttpGet("/available")]
        public List<Direction> GetAvailableDirections()
        {
            return directionService.GetAvailable();
        }

    }

}