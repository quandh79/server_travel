using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _manageHotel;
        public HotelController(IHotelService manageHotel)
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

         [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var hotel = await _manageHotel.Get_By_Name(name);
            return Ok(hotel);
        }
    }
}
