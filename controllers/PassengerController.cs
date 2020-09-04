using Microsoft.AspNetCore.Mvc;

namespace air_ticket_cashier
{
    [ApiController]
    [Route("/api/passengers")]
    public class PassengerController : ControllerBase
    {
        private PassengerService passengerService;

        public PassengerController(PassengerService passengerService)
        {
            this.passengerService = passengerService;
        }

        [HttpGet("/{id}")]
        public Passenger GetPassengerById(int id)
        {
            return passengerService.GetById(id);
        }

        [HttpPost("")]
        public Passenger SaveNewPassenger([FromBody]Passenger passenger)
        {
            return passengerService.Save(passenger);
        }

        [HttpPatch("")]
        public void UpdatePassenger([FromBody]PassengerInfoDto dto)
        {
            passengerService.Update(dto);
        }

        [HttpDelete("/{id}")]
        public void DeletePassengerById(int id)
        {
            passengerService.DeleteById(id);
        }

    }
}