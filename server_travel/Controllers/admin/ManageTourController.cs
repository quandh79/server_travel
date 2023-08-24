using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.Restaurant;
using server_travel.Dtos.Tour;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Controllers.admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagetourController : ControllerBase
    {
        private readonly IManageTour _manageTour;
        public ManagetourController(IManageTour manageTour)
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

        // POST api/<ManageTouristSpotController>
        [HttpPost]
        public async Task<IActionResult> create([FromForm] TourCreateRequest request)
        {
            var tourId = await _manageTour.Create(request);
            if (tourId == 0)
            {
                return BadRequest();
            }
            var tour = await _manageTour.Get_By_Id(tourId);
            return CreatedAtAction(nameof(GetSpotById), new { id = tourId }, tour);
        }

        // PUT api/<ManageTouristSpotController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] TourUpdateRequest request)
        {
            var tourId = await _manageTour.Update(request);
            if (tourId == 0)
            {
                return BadRequest();
            }
            var tour = _manageTour.Get_By_Id(tourId);
            return Ok(new { message = "cap nhat thanh cong", tour });
        }

        // DELETE api/<ManageTouristSpotController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageTour.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "xoa thanh cong" });

            }
            return BadRequest();
        }

    }
}
