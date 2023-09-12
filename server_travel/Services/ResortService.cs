using Microsoft.EntityFrameworkCore;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Services
{
    public class ResortService : IResortService
    {
        private readonly TravelApiContext _context;
        private readonly IUpLoadService _upLoadService;
        public ResortService(TravelApiContext context, IUpLoadService uploadService)
        {
            _context = context;
            _upLoadService = uploadService;
        }

        public async Task<List<ResortViewModel>> GetAll()
        {
            var data = _context.Resorts.Include(img => img.Images).Where(x => x.Status == Status.Active).
                Include(r=>r.Room)
                 .Select(rs => new ResortViewModel
                 {
                     Id = rs.Id,
                     SpotId = rs.SpotId,
                     Name = rs.Name,
                     Location = rs.Location,
                     Cacilities = rs.Cacilities,
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

        public async Task<ResortViewModel> Get_By_Id(int id)
        {
            var resort = await _context.Resorts.Include(img => img.Images)
                .Include(r => r.Room).Select(s => new ResortViewModel()
            {
                Id = s.Id,
                SpotId = s.SpotId,
                Name = s.Name,
                Location = s.Location,
                Cacilities = s.Cacilities,
                Address = s.Address,
                ContactNumber = s.ContactNumber,
                Price = s.Price,
                Description = s.Description,
                    Room = s.Room.Where(r => r.Status == Status.Active).ToList(),

                    Images = s.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = s.Status
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = resort;

            return temp;
        }

        public async Task<ResortViewModel> SearchByName(string name)
        {
             var resort = await _context.Resorts.Include(img => img.Images)
                .Include(r => r.Room).Select(s => new ResortViewModel()
            {
                Id = s.Id,
                SpotId = s.SpotId,
                Name = s.Name,
                Location = s.Location,
                Cacilities = s.Cacilities,
                Address = s.Address,
                ContactNumber = s.ContactNumber,
                Price = s.Price,
                Description = s.Description,
                Room = s.Room.Where(r => r.Status == Status.Active).ToList(),
                Images = s.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = s.Status
            }).FirstOrDefaultAsync(x => x.Name.Contains(name));
            var temp = resort;
            return temp;
        }
    }
}
