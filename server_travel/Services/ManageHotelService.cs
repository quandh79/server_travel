using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.Hotel;
using server_travel.Dtos.touristSpot;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Exceptions;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Services
{
    public class ManageHotelService : IManageHotel
    {
        private readonly IUpLoadService _upLoadService;
        private readonly TravelApiContext _context;
        public ManageHotelService(IUpLoadService upLoadService, TravelApiContext context)
        {
            _upLoadService = upLoadService;
            _context = context;
        }
        public async Task<int> Create(HotelCreateRequest request)
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
            var hotel = new Hotel()
            {
                SpotId = request.SpotId,
                Name = request.Name,
                Location = request.Location,
                Rating = request.Rating,
                Address = request.Address,
                ContactNumber= request.ContactNumber,
                Price= request.Price,
                Description = request.Description,
                Status = Enums.Status.Active,
                Images = hotelImages,
            };

            _context.Hotels.Add(hotel);
            await _context.SaveChangesAsync();


            return hotel.Id;
        }

        public async Task<int> Delete(int id)
        {
            var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                throw new TravelException("khong tim thay TouristSpot");
            }
            hotel.Status = Status.InActive;
            _context.Entry(hotel).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<HotelViewModel>> GetAll()
        {
            var data = _context.Hotels.Include(img => img.Images)
                .Include(r=>r.Room)
                 .Select(rs => new HotelViewModel
                 {
                     Id = rs.Id,
                     SpotId = rs.SpotId,
                     Name = rs.Name,
                     Location = rs.Location,
                     Rating = rs.Rating,
                     Address =rs.Address,
                     ContactNumber = rs.ContactNumber,
                     Price = rs.Price,
                     Description = rs.Description,
                     Room = rs.Room.Where(r=>r.Status == Status.Active).ToList(),
                     Images = rs.Images.Where(i => i.Status == Status.Active).ToList(),
                     Status = rs.Status
                 });
            return await data.ToListAsync();
        }

        public async Task<HotelViewModel> Get_By_Id(int id)
        {
             var hotel = await _context.Hotels.Include(img=>img.Images).Select(s => new HotelViewModel()
            {
                Id = s.Id,
                SpotId = s.SpotId,
                Name = s.Name,
                 Location = s.Location,
                 Rating = s.Rating,
                 Address = s.Address,
                 ContactNumber = s.ContactNumber,
                 Price = s.Price,
                 Room = s.Room.Where(r => r.Status == Status.Active).ToList(),
                 Description = s.Description,                
                Images = s.Images.Where(i=>i.Status == Status.Active).ToList(),
                Status= s.Status
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = hotel;

            return temp;
        }

        public Task<List<HotelViewModel>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(HotelUpdateRequest request)

        {
            if (request.images != null)
            {
                var findHotel = await _context.Hotels.Include(img => img.Images).Select(se => new
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
                            HotelId = request.Id,

                        };
                        tempImages.Add(img);
                    }
                    _context.Images.AddRange(tempImages);
                }
            }
            else
            {
                var findSpot = await _context.Hotels
                    
                    .Include(img => img.Images).Select(se => new
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
                            Status = Status.Active,
                            HotelId = request.Id,

                        };
                        tempImages.Add(img);
                    }
                    _context.Images.AddRange(tempImages);
                }
            }
            var hotel = new Hotel()
            {
                Id= request.Id,
                SpotId = request.SpotId,
                Name = request.Name,
                Location = request.Location,
                Rating = request.Rating,
                Address = request.Address,
                ContactNumber = request.ContactNumber,
                Price = request.Price,
                Description = request.Description,
                Status = Enums.Status.Active,
                Images = null,
               

            };
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel.Id;


        }
    }
}
