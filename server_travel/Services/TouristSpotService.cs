using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.touristSpot;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Services
{
    public class TouristSpotService : ITouristSpotService
    {
        private readonly TravelApiContext _context;
        private readonly IUpLoadService _uploadService;

        public TouristSpotService(TravelApiContext context, IUpLoadService uploadService)
        {
            _context = context;
            _uploadService = uploadService;
        }

        public async Task<List<TourestSpotViewModel>> GetAll()
        {
            var data = _context.Touristspots.Include(img => img.Images).Where(x => x.Status == Status.Active)
                .Include(h => h.Hotels).Where(x => x.Status == Status.Active)
                .Include(r => r.Restaurants).Where(x => x.Status == Status.Active)
                .Include(rs => rs.Resorts).Where(x => x.Status == Status.Active)
                                .Include(rs => rs.Tours).Where(x => x.Status == Status.Active)

                 .Select(rs => new TourestSpotViewModel
                 {
                     Id = rs.Id,
                     Name = rs.Name,
                     Location = rs.Location,
                     Description = rs.Description,
                     Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
                     Hotels = rs.Hotels.Where(p => p.Status == Status.Active).ToList(),
                     Resorts = rs.Resorts.Where(p => p.Status == Status.Active).ToList(),
                     Restaurants = rs.Restaurants.Where(p => p.Status == Status.Active).ToList(),
                     Tours = rs.Tours.Where(p => p.Status == Status.Active).ToList(),

                     status = rs.Status,
                 });
            return await data.ToListAsync();
        }

        public async Task<TourestSpotViewModel> Get_By_Id(int id)
        {
            var spot = await _context.Touristspots.Include(img => img.Images).Where(x => x.Status == Status.Active)
                .Include(h => h.Hotels).Where(x => x.Status == Status.Active)
                .Include(r => r.Restaurants).Where(x => x.Status == Status.Active)
                .Include(rs => rs.Resorts).Where(x => x.Status == Status.Active)
                 .Select(rs => new TourestSpotViewModel
                 {
                     Id = rs.Id,
                     Name = rs.Name,
                     Location = rs.Location,
                     Description = rs.Description,
                     Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
                     Hotels = rs.Hotels.Where(p => p.Status == Status.Active).ToList(),
                     Resorts = rs.Resorts.Where(p => p.Status == Status.Active).ToList(),
                     Restaurants = rs.Restaurants.Where(p => p.Status == Status.Active).ToList(),
                     status = rs.Status,
                 }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = spot;

            return temp;
        }

        public async Task<List<TourestSpotViewModel>> SearchByName(string name)
        {
            var data = _context.Touristspots.Include(img => img.Images)
                .Include(h => h.Tours).ThenInclude(ts => ts.Images.Where(h => h.Status == Status.Active))
                .Include(h => h.Hotels).ThenInclude(ts => ts.Images.Where(h => h.Status == Status.Active))
                .Include(r => r.Restaurants).ThenInclude(ts => ts.Images.Where(h => h.Status == Status.Active))
                .Include(rs => rs.Resorts).ThenInclude(ts => ts.Images.Where(h => h.Status == Status.Active))
                .Where(x => x.Status == Status.Active && x.Name.Contains(name))
                .Select(rs => new TourestSpotViewModel
                {
                    Id = rs.Id,
                    Name = rs.Name,
                    Location = rs.Location,
                    Description = rs.Description,
                    Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
                    Hotels = rs.Hotels.Where(p => p.Status == Status.Active).ToList(),
                    Resorts = rs.Resorts.Where(p => p.Status == Status.Active).ToList(),
                    Tours = rs.Tours.Where(p => p.Status == Status.Active).ToList(),
                    Restaurants = rs.Restaurants.Where(p => p.Status == Status.Active).ToList(),
                    status = rs.Status,
                });

            return await data.ToListAsync();
        }


    }
}
