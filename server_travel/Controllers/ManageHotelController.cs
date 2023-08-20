using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.Hotel;
using server_travel.Dtos.touristSpot;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageHotelController : ControllerBase
    {
        private readonly IManageHotel _manageHotel;
        public ManageHotelController(IManageHotel manageHotel)
        {
            _manageHotel = manageHotel;
        }
        [HttpGet]
        public async Task<List<HotelViewModel>> GetAll()
        {
            var data = await _manageHotel.GetAll();
            return data;
        }

        // GET api/<ManageTouristSpotController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpotById(int id)
        {
            var hotel = await _manageHotel.Get_By_Id(id);
            return Ok(hotel);
        }

        // POST api/<ManageTouristSpotController>
        [HttpPost]
        public async Task<IActionResult> create([FromForm] HotelCreateRequest request)
        {
            var hotelId = await _manageHotel.Create(request);
            if (hotelId == 0)
            {
                return BadRequest();
            }
            var spot = await _manageHotel.Get_By_Id(hotelId);
            return CreatedAtAction(nameof(GetSpotById), new { id = hotelId }, spot);
        }

        // PUT api/<ManageTouristSpotController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] HotelUpdateRequest request)
        {
            var hotelId = await _manageHotel.Update(request);
            if (hotelId == 0)
            {
                return BadRequest();
            }
            var hotel = _manageHotel.Get_By_Id(hotelId);
            return Ok(new { message = "cap nhat thanh cong", hotel });
        }

        // DELETE api/<ManageTouristSpotController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageHotel.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "xoa thanh cong" });

            }
            return BadRequest();
        }
    }
}
