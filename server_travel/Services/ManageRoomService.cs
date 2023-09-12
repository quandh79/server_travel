using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.Hotel;
using server_travel.Dtos.Room;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Exceptions;
using server_travel.Interfaces;
using server_travel.Models;
using server_travel.ViewModels;

namespace server_travel.Services
{
    public class ManageRoomService : IManageRoom
    {
        private readonly IUpLoadService _upLoadService;
        private readonly TravelApiContext _context;
        public ManageRoomService(IUpLoadService upLoadService, TravelApiContext context)
        {
            _upLoadService = upLoadService;
            _context = context;
        }
        public async Task<int> Create(CreateRoomRequest request)
        {
            var hotelImages = new List<Image>();
            foreach (var image in request.images)
            {
                if (image == null || image.Length <= 0)
                {
                    throw new TravelException("Không tìm thấy hình ảnh.");
                }
                var imageUrl = await _upLoadService.UploadImageAsync(image);
                hotelImages.Add(new Image
                {
                    ImageUrl = imageUrl,
                    Status = Status.Active
                });

            }
            var hotel = new Room()
            {
                HotelId = request.HotelId,
                ResortId = request.ResortId,
                Name= request.Name,
                Sale = request.Sale,
                Price=  request.Price,
                Description= request.Description,
                Slot = request.Slot,
                Images = hotelImages,
                Status= Status.Active
            };

            _context.Rooms.Add(hotel);
            await _context.SaveChangesAsync();


            return hotel.Id;
        }

        public async Task<int> Delete(int id)
        {
            var hotel = await _context.Rooms.FindAsync(id);
            if (hotel == null)
            {
                throw new TravelException("khong tim thay Room");
            }
            hotel.Status = Status.InActive;
            _context.Entry(hotel).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<RoomViewModel>> GetAll()
        {
            var data = _context.Rooms.Include(img => img.Images).Where(x => x.Status == Status.Active)
                 .Select(rs => new RoomViewModel
                 {
                     Id = rs.Id,
                     HotelId= rs.HotelId,
                     ResortId = rs.ResortId,
                     Name= rs.Name,
                     Price = rs.Price,
                     Sale = rs.Sale,
                     Slot= rs.Slot,
                     Description = rs.Description,
                     Images = rs.Images.Where(i => i.Status == Status.Active).ToList(),
                     Status = rs.Status
                 });
            return await data.ToListAsync();
        }

        public async Task<List<RoomViewModel>> GetRoomsByHotelId(int hotelId)
        {
            var rooms = await _context.Rooms
                .Include(rs => rs.Images)
                .Where(rs => rs.HotelId == hotelId && rs.Status == Status.Active)
                .Select(rs => new RoomViewModel
                {
                    Id = rs.Id,
                    HotelId = rs.HotelId,
                    ResortId = rs.ResortId,
                    Name = rs.Name,
                    Price = rs.Price,
                    Sale = rs.Sale,
                    Slot = rs.Slot,
                    Description = rs.Description,
                    Images = rs.Images,
                    Status = rs.Status
                })
                .ToListAsync();

            return rooms;
        }

        public async Task<List<RoomViewModel>> GetRoomsByResortId(int resortId)
        {
            var rooms = await _context.Rooms
                .Include(rs => rs.Images)
                .Where(rs => rs.ResortId == resortId && rs.Status == Status.Active)
                .Select(rs => new RoomViewModel
                {
                    Id = rs.Id,
                    HotelId = rs.HotelId,
                    ResortId = rs.ResortId,
                    Name = rs.Name,
                    Price = rs.Price,
                    Sale = rs.Sale,
                    Slot = rs.Slot,
                    Description = rs.Description,
                    Images = rs.Images,
                    Status = rs.Status
                })
                .ToListAsync();

            return rooms;
        }

        public async Task<RoomViewModel> Get_By_Id(int id)
        {
            var hotel = await _context.Rooms.Include(img => img.Images).Select(rs => new RoomViewModel()
            {
                Id = rs.Id,
                HotelId = rs.HotelId,
                ResortId = rs.ResortId,
                Name = rs.Name,
                Price = rs.Price,
                Sale = rs.Sale,
                Slot = rs.Slot,
                Description = rs.Description,
                Images = rs.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = rs.Status
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = hotel;

            return temp;
        }

        public async Task<int> Update(UpdateRoomRequest request)

        {
            if (request.images != null)
            {
                var findHotel = await _context.Rooms.Include(img => img.Images).Select(se => new
                {
                    id = se.Id,
                    Image = se.Images.Where(e => e.Status == Status.Active).ToList()
                }
                ).FirstOrDefaultAsync(p => p.id == request.Id);
                foreach (var image in findHotel.Image)
                {
                    if (request.images.Contains(image.Id) == false)
                    {
                        image.Status = Status.InActive;
                        _context.Entry(image).State = EntityState.Modified;
                    }
                }
                if (request.files != null)
                {
                    var tempImages = new List<Image>();
                    foreach (IFormFile f in request.files)
                    {
                        var url = await _upLoadService.UploadImageAsync(f);
                        var img = new Image()
                        {
                            ImageUrl = url,
                            Status = Status.Active,
                            RoomId = request.Id,

                        };
                        tempImages.Add(img);
                    }
                    _context.Images.AddRange(tempImages);
                }
            }
            else
            {
                var findSpot = await _context.Rooms.Include(img => img.Images).Select(se => new
                {
                    id = se.Id,
                    Image = se.Images.Where(e => e.Status == Status.Active).ToList()
                }
               ).FirstOrDefaultAsync(p => p.id == request.Id);
                foreach (var image in findSpot.Image)
                {
                        image.Status = Status.InActive;
                        _context.Entry(image).State = EntityState.Modified;
                }
                if (request.files != null)
                {
                    var tempImages = new List<Image>();
                    foreach (IFormFile f in request.files)
                    {
                        var url = await _upLoadService.UploadImageAsync(f);
                        var img = new Image()
                        {
                            ImageUrl = url,
                            SpotId = request.Id,
                            Status = Status.Active

                        };
                        tempImages.Add(img);
                    }
                    _context.Images.AddRange(tempImages);
                }
            }
            var hotel = new Room()
            {
                Id = request.Id,
                Name = request.Name,
                Sale = request.Sale,
                Price = request.Price,
                Description = request.Description,
                Slot = request.Slot,
                Images = null,
                Status = Status.Active


            };
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel.Id;


        }
    }
}
