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
        private readonly IUpLoadService _uploadService;

        public ManageVehicle(TravelApiContext context, IUpLoadService uploadService)
        {
            _context = context;
            _uploadService = uploadService;
        }
        public async Task<int> Create(CreateVehicleRequest request)
        {
            var spotImages = new List<Image>();
            foreach (var image in request.images)
            {
                if (image == null || image.Length <= 0)
                {
                    throw new TravelException("Không tìm thấy hình ảnh.");
                }
                var imageUrl = await _uploadService.UploadImageAsync(image);
                spotImages.Add(new Image
                {
                    ImageUrl = imageUrl,
                    Status = Status.Active
                });

            }
            var vehicle = new Vehicle()
            {
                TourId = request.TourId,
                Name = request.Name,
                Type = request.Type,
                Price = request.Price,
                Description = request.Description,
                Images = spotImages,
                Status = Status.Active
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
                TourId = rs.TourId,
                Name = rs.Name,
                Type = rs.Type,
                Price = rs.Price,
                Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
                Description = rs.Description,
                Status = rs.Status,

            }).ToListAsync();
            return data;
        }

        public async Task<List<VehicleViewModel>> GetByTourId(int id)
        {
            var data = await _context.Vehicles.Where(v => v.TourId == id).Select(rs => new VehicleViewModel()
            {
                Id = rs.Id,
                TourId = rs.TourId,
                Name = rs.Name,
                Type = rs.Type,
                Price = rs.Price,
                Description = rs.Description,
                Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
                Status = rs.Status,
            }).ToListAsync();

                var temp = data;

                return temp;
        }

        public async Task<VehicleViewModel> Get_By_Id(int id)
        {
            var data = await _context.Vehicles.Where(v => v.Id == id).Select(rs => new VehicleViewModel()
            {
                TourId = rs.TourId,
                Name = rs.Name,
                Type = rs.Type,
                Price = rs.Price,
                Description = rs.Description,
                Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
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
                TourId = request.TourId,
                Name = request.Name,
                Type = request.Type,
                Price = request.Price,
                Description = request.Description,
                Status = Status.Active,

            };

            _context.Entry(vehicle).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
