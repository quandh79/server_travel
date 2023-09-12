using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.District;
using server_travel.Entities;
using server_travel.Interfaces;
using server_travel.ViewModels;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IManageDistrict _manageDistrict;
        public DistrictController(IManageDistrict manageDistrict)
        {
            _manageDistrict = manageDistrict;
        }
        // GET: api/<ManageTouristSpotController>
        [HttpGet]
        public async Task<List<DistrictViewModel>> GetAll()
        {
            var data = await _manageDistrict.GetAll();
            return data;
        }

        [HttpGet("paging")]
        public async Task<List<DistrictViewModel>> GetAllPaging(int? limit, int? page)
        {
            var data = await _manageDistrict.GetAllPaging(limit,page);
            return data;
        }

        // GET api/<ManageTouristSpotController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpotById(int id)
        {
            var spot = await _manageDistrict.Get_By_Id(id);
            return Ok(spot);
        }

        [HttpGet("SearchByName/{name}")]
        public async Task<List<DistrictViewModel>> SearchByName(string name)
        {
            var data = await _manageDistrict.SearchByName(name);
            return data;
        }

        [HttpGet("Search/{name}")]
        public async Task<List<object>> Search(string name)
        {
            var data = await _manageDistrict.Search(name);
            return data;
        }



    }
}
