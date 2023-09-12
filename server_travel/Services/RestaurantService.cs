using Microsoft.EntityFrameworkCore;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IUpLoadService _upLoadService;
        private readonly TravelApiContext _context;
        public RestaurantService(IUpLoadService upLoadService, TravelApiContext context)
        {
            _upLoadService = upLoadService;
            _context = context;
        }

        public async Task<List<RestaurantViewModel>> GetAll()
        {
            var data = _context.Restaurants.Include(img => img.Images).Where(x => x.Status == Status.Active)
                 .Select(rs => new RestaurantViewModel
                 {
                     Id = rs.Id,
                     SpotId = rs.SpotId,
                     Name = rs.Name,
                     Location = rs.Location,
                     CuisineType = rs.CuisineType,
                     Address = rs.Address,
                     ContactNumber = rs.ContactNumber,
                     Price = rs.Price,
                     Description = rs.Description,
                     Images = rs.Images.Where(i => i.Status == Status.Active).ToList(),
                     Status = rs.Status
                 });
            return await data.ToListAsync();
        }

        public async Task<RestaurantViewModel> Get_By_Id(int id)
        {
            var restaurant = await _context.Restaurants.Include(img => img.Images).Select(s => new RestaurantViewModel()
            {
                Id = s.Id,
                SpotId = s.SpotId,
                Name = s.Name,
                Location = s.Location,
                CuisineType = s.CuisineType,
                Address = s.Address,
                ContactNumber = s.ContactNumber,
                Price = s.Price,
                Description = s.Description,
                Images = s.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = s.Status
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = restaurant;

            return temp;
        }

        public async Task<RestaurantViewModel> SearchByName(string name)
        {
             var restaurant = await _context.Restaurants.Include(img => img.Images).Select(s => new RestaurantViewModel()
            {
                Id = s.Id,
                SpotId = s.SpotId,
                Name = s.Name,
                Location = s.Location,
                CuisineType = s.CuisineType,
                Address = s.Address,
                ContactNumber = s.ContactNumber,
                Price = s.Price,
                Description = s.Description,
                Images = s.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = s.Status
            }).FirstOrDefaultAsync(x => x.Name.Contains(name));
            var temp = restaurant;

            return temp;
        }
    }
}
