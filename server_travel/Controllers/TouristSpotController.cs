using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.touristSpot;
using server_travel.Interfaces;
using server_travel.Models;
using server_travel.Services;
using server_travel.ViewModels;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristSpotController : ControllerBase
    {
        private readonly ITouristSpotService _manageTourist;
        public TouristSpotController(ITouristSpotService manageTourist)
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

        [HttpGet("SearchByName/{name}")]
        public async Task<List<TourestSpotViewModel>> SearchByName(string name)
        {
            var data = await _manageTourist.SearchByName(name);
            return data;
        }


    }
}
