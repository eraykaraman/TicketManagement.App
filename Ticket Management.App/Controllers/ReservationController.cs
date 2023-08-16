using Microsoft.AspNetCore.Mvc;
using TicketManagement.App.Data.Entities;
using TicketManagement.App.Services;

namespace TicketManagement.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Reserve")]
        public ActionResult<ReserveResult> Reserve([FromBody] ReservationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Geçersiz rezervasyon isteği.");
            }

            var result = _reservationService.Reserve(request);

            if (result.RezervasyonYapilabilir)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
