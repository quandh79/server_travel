using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResortController : ControllerBase
    {
        private readonly IResortService _manageResort;
        public ResortController(IResortService manageResort)
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

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await _manageResort.SearchByName(name);
            return Ok(data);
        }
    }
}
