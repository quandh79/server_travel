using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.District;
using server_travel.Dtos.touristSpot;
using server_travel.Entities;
using server_travel.Interfaces;
using server_travel.Models;
using server_travel.ViewModels;

namespace server_travel.Controllers.admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageDistrictController : ControllerBase
    {
        private readonly IManageDistrict _manageDistrict;
        public ManageDistrictController(IManageDistrict manageDistrict)
        {
            _manageDistrict= manageDistrict;
        }
        // GET: api/<ManageTouristSpotController>
        [HttpGet]
        public async Task<List<DistrictViewModel>> GetAll()
        {
            var data = await _manageDistrict.GetAll();
            return data;
        }

        // GET api/<ManageTouristSpotController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpotById(int id)
        {
            var spot = await _manageDistrict.Get_By_Id(id);
            return Ok(spot);
        }

        // POST api/<ManageTouristSpotController>
        [HttpPost]
        public async Task<IActionResult> create([FromForm] CreateDistrictRequest request)
        {
            var spotId = await _manageDistrict.Create(request);
            if (spotId == 0)
            {
                return BadRequest();
            }
            var spot = await _manageDistrict.Get_By_Id(spotId);
            return CreatedAtAction(nameof(GetSpotById), new { id = spotId }, spot);
        }

        // PUT api/<ManageTouristSpotController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] UpdateDistrictRequest request)
        {
            var touristSpotId = await _manageDistrict.Update(request);
            if (touristSpotId == 0)
            {
                return BadRequest();
            }
            var spot = _manageDistrict.Get_By_Id(touristSpotId);
            return Ok(new { message = "cap nhat thanh cong", spot });
        }

        // DELETE api/<ManageTouristSpotController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageDistrict.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "xoa thanh cong" });

            }
            return BadRequest();
        }
    }
}

