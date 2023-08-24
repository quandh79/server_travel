using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_travel.Entities;
using server_travel.ViewModels;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly TravelApiContext _context;
        public DistrictController(TravelApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var districts =  _context.Districts.Include(i=>i.Images).Where(i=>i.Status==Enums.Status.Active)
                                              .Include(t=>t.Touristspots).Where(t => t.Status == Enums.Status.Active).ToArray();
            if(districts == null)
            {
                return NotFound();
            }
            return Ok(districts);
        }
    }
}
