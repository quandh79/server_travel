using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.Tour;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Services
{
    public class TourService : ITourService
    {
        private readonly IUpLoadService _upLoadService;
        private readonly TravelApiContext _context;
        public TourService(IUpLoadService upLoadService, TravelApiContext context)
        {
            _upLoadService = upLoadService;
            _context = context;
        }
        public async Task<List<TourViewModel>> GetAll()
        {
            var data = _context.Tours.Include(img => img.Images).Where(x => x.Status == Status.Active)
                 .Select(rs => new TourViewModel
                 {
                     Id = rs.Id,
                     SpotId = rs.SpotId,
                     Name=rs.Name,
                     TravelDate = rs.TravelDate,
                     Duration = rs.Duration,
                     Price = rs.Price,
                     TravelType = rs.TravelType,
                     Person= rs.Person,
                     Description = rs.Description,
                     Images = rs.Images.Where(i => i.Status == Status.Active).ToList(),
                     Status = rs.Status
                 });
            return await data.ToListAsync();
        }

        public async Task<TourViewModel> Get_By_Id(int id)
        {
            var restaurant = await _context.Tours.Include(img => img.Images).Select(rs => new TourViewModel()
            {
                Id = rs.Id,
                SpotId = rs.SpotId,
                Name=rs.Name,
                TravelDate = rs.TravelDate,
                Duration = rs.Duration,
                Price = rs.Price,
                TravelType = rs.TravelType,
                Person = rs.Person,
                Description = rs.Description,
                Images = rs.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = rs.Status
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = restaurant;

            return temp;
        }

        public async Task<List<Tour>> Search(TourSearchRequest request)
        {
            IQueryable<Tour> query = _context.Tours.Include(t => t.District).Include(t => t.Spot);

            if (!string.IsNullOrEmpty(request.DistrictName))
            {
                query = query.Where(t => t.District != null && t.District.Name.ToLower().Contains(request.DistrictName.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.TravelType))
            {
                query = query.Where(t => t.TravelType.ToLower() == request.TravelType.ToLower());
            }

            if (request.Person.HasValue)
            {
                query = query.Where(t => t.Person == request.Person);
            }

            if (request.TravelDate.HasValue)
            {
                query = query.Where(t => t.TravelDate.HasValue && t.TravelDate.Value.Date == request.TravelDate.Value.Date);
            }

            List<Tour> searchResults = await query.ToListAsync();
            return searchResults;
        }
    }
}
