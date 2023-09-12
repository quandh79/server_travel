using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _manageRestaurant;
        public RestaurantController(IRestaurantService manageRestaurant)
        {
            _manageRestaurant = manageRestaurant;
        }

        [HttpGet]
        public async Task<List<RestaurantViewModel>> GetAll()
        {
            var data = await _manageRestaurant.GetAll();
            return data;
        }

        // GET api/<ManageTouristSpotController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpotById(int id)
        {
            var data = await _manageRestaurant.Get_By_Id(id);
            return Ok(data);
        }
        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await _manageRestaurant.SearchByName(name);
            return Ok(data);
        }
    }
}
