using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.Hotel;
using server_travel.Dtos.Restaurant;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Controllers.admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageRestaurantController : ControllerBase
    {
        private readonly IManageRestaurant _manageRestaurant;
        public ManageRestaurantController(IManageRestaurant manageRestaurant)
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

        // POST api/<ManageTouristSpotController>
        [HttpPost]
        public async Task<IActionResult> create([FromForm] RestaurantCreateRequest request)
        {
            var restaurantId = await _manageRestaurant.Create(request);
            if (restaurantId == 0)
            {
                return BadRequest();
            }
            var restaurant = await _manageRestaurant.Get_By_Id(restaurantId);
            return CreatedAtAction(nameof(GetSpotById), new { id = restaurantId }, restaurant);
        }

        // PUT api/<ManageTouristSpotController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromForm] RestaurantUpdateRequest request)
        {
            var restaurantId = await _manageRestaurant.Update(request);
            if (restaurantId == 0)
            {
                return BadRequest();
            }
            var restaurant = _manageRestaurant.Get_By_Id(restaurantId);
            return Ok(new { message = "cap nhat thanh cong", restaurant });
        }

        // DELETE api/<ManageTouristSpotController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageRestaurant.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "xoa thanh cong" });

            }
            return BadRequest();
        }

    }
}
