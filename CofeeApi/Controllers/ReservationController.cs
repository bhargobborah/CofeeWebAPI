using CofeeApi.Data;
using CofeeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CofeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly CofeeDbContext _cofeeDbContext;

        public ReservationController(CofeeDbContext cofeeDbContext)
        {
            _cofeeDbContext = cofeeDbContext;
        }

        [HttpPost]
        public IActionResult Post(Reservation reservation)
        {
            _cofeeDbContext.Reservations.Add(reservation);
            _cofeeDbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}