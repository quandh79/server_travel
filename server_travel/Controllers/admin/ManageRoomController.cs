using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.Hotel;
using server_travel.Dtos.Room;
using server_travel.Interfaces;
using server_travel.Models;
using server_travel.ViewModels;

namespace server_travel.Controllers.admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageRoomController : ControllerBase
    {
        private readonly IManageRoom _manageHotel;
        public ManageRoomController(IManageRoom manageHotel)
        {
            _manageHotel = manageHotel;
        }
        [HttpGet]
        public async Task<List<RoomViewModel>> GetAll()
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

        // GET api/<ManageTouristSpotController>/5
        [HttpGet("GetRoomByHotelId/{hotelId}")]
        public async Task<List<RoomViewModel>> GetRoomsByHotelId(int hotelId)
        {
            var hotel = await _manageHotel.GetRoomsByHotelId(hotelId);
            return hotel;
        }

        [HttpGet("GetRoomByResortId/{resortId}")]
        public async Task<List<RoomViewModel>> GetRoomsByResortId(int resortId)
        {
            var hotel = await _manageHotel.GetRoomsByResortId(resortId);
            return hotel;
        }

        // POST api/<ManageTouristSpotController>
        [HttpPost]
        public async Task<IActionResult> create([FromForm] CreateRoomRequest request)
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
        public async Task<IActionResult> Update([FromForm] UpdateRoomRequest request)
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
