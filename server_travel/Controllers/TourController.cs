using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.Tour;
using server_travel.Entities;
using server_travel.Interfaces;
using server_travel.Models;
using server_travel.Services;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _manageTour;
        public TourController(ITourService manageTour)
        {
            _manageTour = manageTour;
        }

        [HttpGet]
        public async Task<List<TourViewModel>> GetAll()
        {
            var data = await _manageTour.GetAll();
            return data;
        }

        // GET api/<ManageTouristSpotController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpotById(int id)
        {
            var data = await _manageTour.Get_By_Id(id);
            return Ok(data);
        }
        [HttpGet("search")]
        public async Task<ActionResult<List<Tour>>> SearchTours([FromQuery] TourSearchRequest searchRequest)
        {
            try
            {
                var results = await _manageTour.Search(searchRequest);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
