using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.TravelPlan;
using server_travel.Entities;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPlanController : ControllerBase
    {
        private readonly TravelApiContext _context;
        public TravelPlanController(TravelApiContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create([FromForm] PlanCreateRequest request)
        {
            try
            {
                var plan = new TravelPlan()
                {
                    TourId= request.TourId,
                    Title= request.Title,
                    Description= request.Description,
                };
                _context.TravelPlans.Add(plan);
                _context.SaveChanges();
                return Ok(plan);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var plan = _context.TravelPlans.Find(id);
            if (plan == null)
            {
                return BadRequest();
            }
            _context.TravelPlans.Remove(plan);
            _context.SaveChanges();
            return Ok("xoa thanh cong");
        }

        [HttpGet("GetByTourId/{tourId}")]
        public async Task<IActionResult> GetByTourId(int tourId)
        {
            try
            {
                var plans = await _context.TravelPlans
                    .Where(plan => plan.TourId == tourId)
                    .ToListAsync();

                return Ok(plans);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
