using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.Tour;
using server_travel.Dtos.Vehicle;
using server_travel.Entities;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Controllers.admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageVehicleController : ControllerBase
    {
        private readonly IManageVehicle _manageVehicle;
        public ManageVehicleController(IManageVehicle manageVehicle)
        {
            _manageVehicle = manageVehicle;
        }

        [HttpGet]
        public async Task<List<VehicleViewModel>> GetAll()
        {
            var data = await _manageVehicle.GetAll();
            return data;
        }

        // GET api/<ManageTouristSpotController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpotById(int id)
        {
            var data = await _manageVehicle.Get_By_Id(id);
            return Ok(data);
        }

        // POST api/<ManageTouristSpotController>
        [HttpPost]
        public async Task<IActionResult> create([FromForm] CreateVehicleRequest request)
        {
            var tourId = await _manageVehicle.Create(request);
            if (tourId == 0)
            {
                return BadRequest();
            }
            var tour = await _manageVehicle.Get_By_Id(tourId);
            return CreatedAtAction(nameof(GetSpotById), new { id = tourId }, tour);
        }

        // PUT api/<ManageTouristSpotController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] UpdateVehicleRequest request)
        {
            var tourId = await _manageVehicle.Update(request);
            if (tourId == 0)
            {
                return BadRequest();
            }
            var tour = _manageVehicle.Get_By_Id(tourId);
            return Ok(new { message = "cap nhat thanh cong", tour });
        }

        // DELETE api/<ManageTouristSpotController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageVehicle.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "xoa thanh cong" });

            }
            return BadRequest();
        }
    }
}
