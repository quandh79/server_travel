using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.Hotel;
using server_travel.Dtos.Resort;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Controllers.admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageResortController : ControllerBase
    {
        private readonly IManageResort _manageResort;
        public ManageResortController(IManageResort manageResort)
        {
            _manageResort = manageResort;
        }
        [HttpGet]
        public async Task<List<ResortViewModel>> GetAll()
        {
            var data = await _manageResort.GetAll();
            return data;
        }

        // GET api/<ManageTouristSpotController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpotById(int id)
        {
            var data = await _manageResort.Get_By_Id(id);
            return Ok(data);
        }

        // POST api/<ManageTouristSpotController>
        [HttpPost]
        public async Task<IActionResult> create([FromForm] ResortCreateRequest request)
        {
            var resortId = await _manageResort.Create(request);
            if (resortId == 0)
            {
                return BadRequest();
            }
            var resort = await _manageResort.Get_By_Id(resortId);
            return CreatedAtAction(nameof(GetSpotById), new { id = resortId }, resort);
        }

        // PUT api/<ManageTouristSpotController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] ResortUpdateRequest request)
        {
            var resortId = await _manageResort.Update(request);
            if (resortId == 0)
            {
                return BadRequest();
            }
            var resort = _manageResort.Get_By_Id(resortId);
            return Ok(new { message = "cap nhat thanh cong", resort });
        }

        // DELETE api/<ManageTouristSpotController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageResort.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "xoa thanh cong" });

            }
            return BadRequest();
        }

    }
}
