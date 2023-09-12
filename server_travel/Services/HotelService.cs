using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.Hotel;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Services
{
    public class HotelService : IHotelService
    {
        private readonly IUpLoadService _upLoadService;
        private readonly TravelApiContext _context;
        public HotelService(IUpLoadService upLoadService, TravelApiContext context)
        {
            _upLoadService = upLoadService;
            _context = context;
        }
        public async Task<List<HotelViewModel>> GetAll()
        {

            var data = _context.Hotels.Include(img => img.Images).Where(x => x.Status == Status.Active)
                 .Select(rs => new HotelViewModel
                 {
                     Id = rs.Id,
                     SpotId = rs.SpotId,
                     Name = rs.Name,
                     Location = rs.Location,
                     Rating = rs.Rating,
                     Address = rs.Address,
                     ContactNumber = rs.ContactNumber,
                     Price = rs.Price,
                     Description = rs.Description,
                     Room = rs.Room.Where(r => r.Status == Status.Active).ToList(),
                     Images = rs.Images.Where(i => i.Status == Status.Active).ToList(),
                     Status = rs.Status
                 });
            return await data.ToListAsync();
        }

        public async Task<HotelViewModel> Get_By_Id(int id)
        {
            var hotel = await _context.Hotels.Include(img => img.Images).Select(s => new HotelViewModel()
            {
                Id = s.Id,
                SpotId = s.SpotId,
                Name = s.Name,
                Location = s.Location,
                Rating = s.Rating,
                Address = s.Address,
                ContactNumber = s.ContactNumber,
                Price = s.Price,
                Description = s.Description,
                Room = s.Room.Where(r => r.Status == Status.Active).ToList(),
                Images = s.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = s.Status
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = hotel;

            return temp;
        }

        public async Task<HotelViewModel> Get_By_Name(string name)
        {
            var hotel = await _context.Hotels.Include(img => img.Images).Select(s => new HotelViewModel()
            {
                Id = s.Id,
                SpotId = s.SpotId,
                Name = s.Name,
                Location = s.Location,
                Rating = s.Rating,
                Address = s.Address,
                ContactNumber = s.ContactNumber,
                Price = s.Price,
                Description = s.Description,
                Room = s.Room.Where(r => r.Status == Status.Active).ToList(),
                Images = s.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = s.Status
            }).FirstOrDefaultAsync(x=>x.Name.Contains(name));
            var temp = hotel;

            return temp;
        }


    }
}
