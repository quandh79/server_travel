using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.Vehicle;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Exceptions;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Services
{
    public class ManageVehicle : IManageVehicle
    {
        private readonly TravelApiContext _context;
        public ManageVehicle(TravelApiContext context)
        {
            _context = context;
        }
        public async Task<int> Create(CreateVehicleRequest request)
        {
            var vehicle = new Vehicle()
            {
                SpotId = request.SpotId,
                Name = request.Name,
                Type = request.Type,
                Price = request.Price,
                Description = request.Description,
                Status = request.Status,
            };
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle.Id;
        }

        public async Task<int> Delete(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if(vehicle == null)
            {
                throw new TravelException("khong tim thay vehicle");
            }
            vehicle.Status = Status.InActive;
            _context.Entry(vehicle).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<VehicleViewModel>> GetAll()
        {
            var data = await _context.Vehicles.Select(rs => new VehicleViewModel()
            {
                SpotId = rs.SpotId,
                Name = rs.Name,
                Type = rs.Type,
                Price = rs.Price,
                Description = rs.Description,
                Status = rs.Status,

            }).ToListAsync();
            return data;
        }
        public async Task<VehicleViewModel> Get_By_Id(int id)
        {
            var data = await _context.Vehicles.Where(v => v.Id == id).Select(rs => new VehicleViewModel()
            {
                SpotId = rs.SpotId,
                Name = rs.Name,
                Type = rs.Type,
                Price = rs.Price,
                Description = rs.Description,
                Status = rs.Status,
            }).FirstOrDefaultAsync();

                var temp = data;

                return temp;
           }

        public async Task<int> Update(UpdateVehicleRequest request)
        {
            var vehicle = new Vehicle()
            {
                Id = request.Id,
                SpotId = request.SpotId,
                Name = request.Name,
                Type = request.Type,
                Price = request.Price,
                Description = request.Description,
                Status = request.Status,

            };

            _context.Entry(vehicle).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
