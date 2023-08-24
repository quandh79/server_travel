using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.touristSpot;
using server_travel.Entities;
using server_travel.Interfaces;
using server_travel.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server_travel.Controllers.admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageTouristSpotController : ControllerBase
    {
        private readonly IManageTouristSpot _manageTourist;
        public ManageTouristSpotController(IManageTouristSpot manageTourist)
        {
            _manageTourist = manageTourist;
        }
        // GET: api/<ManageTouristSpotController>
        [HttpGet]
        public async Task<List<TourestSpotViewModel>> GetAll()
        {
            var data = await _manageTourist.GetAll();
            return data;
        }

        // GET api/<ManageTouristSpotController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpotById(int id)
        {
            var spot = await _manageTourist.Get_By_Id(id);
            return Ok(spot);
        }

        // POST api/<ManageTouristSpotController>
        [HttpPost]
        public async Task<IActionResult> create([FromForm] SpotCreateRequest request)
        {
            var spotId = await _manageTourist.Create(request);
            if (spotId == 0)
            {
                return BadRequest();
            }
            var spot = await _manageTourist.Get_By_Id(spotId);
            return CreatedAtAction(nameof(GetSpotById), new { id = spotId }, spot);
        }

        // PUT api/<ManageTouristSpotController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] SpotUpdateRequest request)
        {
            var touristSpotId = await _manageTourist.Update(request);
            if (touristSpotId == 0)
            {
                return BadRequest();
            }
            var spot = _manageTourist.Get_By_Id(touristSpotId);
            return Ok(new { message = "cap nhat thanh cong", spot });
        }

        // DELETE api/<ManageTouristSpotController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageTourist.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "xoa thanh cong" });

            }
            return BadRequest();
        }
    }
}
