using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.District;
using server_travel.Dtos.touristSpot;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Exceptions;
using server_travel.Interfaces;
using server_travel.Models;
using server_travel.ViewModels;

namespace server_travel.Services
{
    public class ManageDistrict : IManageDistrict
    {
        private readonly TravelApiContext _context;
        private readonly IUpLoadService _uploadService;

        public ManageDistrict(TravelApiContext context, IUpLoadService uploadService)
        {
            _context = context;
            _uploadService = uploadService;
        }
        //public async Task<string> SaveFile(IFormFile file)
        //{
        //    var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
        //    await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
        //    return $"https://localhost:5001/MyImages/{fileName}";
        //}
        public async Task<int> Create(CreateDistrictRequest spot)
        {

            var spotImages = new List<Image>();
            foreach (var image in spot.images)
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
            var tourstspot = new District()
            {
                Name = spot.Name,
                Description = spot.Description,
                Status = Enums.Status.Active,
                Images = spotImages,
            };

            _context.Districts.Add(tourstspot);
            await _context.SaveChangesAsync();


            return tourstspot.Id;
        }

        public async Task<int> Delete(int id)
        {
            var touristspot = await _context.Districts.FindAsync(id);
            if (touristspot == null)
            {
                throw new TravelException("khong tim thay TouristSpot");
            }
            touristspot.Status = Status.InActive;
            _context.Entry(touristspot).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<DistrictViewModel>> GetAll()
        {
            var data = _context.Districts.Include(img => img.Images).Where(x => x.Status == Status.Active)
                 .Select(rs => new DistrictViewModel
                 {
                     Id = rs.Id,
                     Name = rs.Name,
                     Description = rs.Description,
                     Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
                     Status = rs.Status,
                 });
            return await data.ToListAsync();
        }

        public async Task<DistrictViewModel> Get_By_Id(int id)
        {
            var spot = await _context.Districts.Include(img => img.Images).Select(s => new DistrictViewModel()
            {
                Id = s.Id,
                Name = s.Name,            
                Description = s.Description,
                Images = s.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = s.Status,
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = spot;

            return temp;
        }

        public async Task<int> Update(UpdateDistrictRequest spot)

        {
            if (spot.images != null)
            {
                var findSpot = await _context.Districts.Include(img => img.Images).Select(se => new
                {
                    id = se.Id,
                    Image = se.Images.Where(e => e.Status == Status.Active).ToList()
                }
                ).FirstOrDefaultAsync(p => p.id == spot.Id);
                foreach (var image in findSpot.Image)
                {
                    if (spot.images.Contains(image.Id) == false)
                    {
                        image.Status = Status.InActive;
                        _context.Entry(image).State = EntityState.Modified;
                    }
                }
                if (spot.files != null)
                {
                    var tempImages = new List<Image>();
                    foreach (IFormFile f in spot.files)
                    {
                        var url = await _uploadService.UploadImageAsync(f);
                        var img = new Image()
                        {
                            ImageUrl = url,
                            Status = Status.Active,
                            SpotId = spot.Id,

                        };
                        tempImages.Add(img);
                    }
                    _context.Images.AddRange(tempImages);
                }
            }
            else
            {
                var findSpot = await _context.Districts.Include(img => img.Images).Select(se => new
                {
                    id = se.Id,
                    Image = se.Images.Where(e => e.Status == Status.Active).ToList()
                }
               ).FirstOrDefaultAsync(p => p.id == spot.Id);
                foreach (var image in findSpot.Image)
                {
                    if (spot.images.Contains(image.Id) == false)
                    {
                        image.Status = Status.InActive;
                        _context.Entry(image).State = EntityState.Modified;
                    }
                }
                if (spot.files != null)
                {
                    var tempImages = new List<Image>();
                    foreach (IFormFile f in spot.files)
                    {
                        var url = await _uploadService.UploadImageAsync(f);
                        var img = new Image()
                        {
                            ImageUrl = url,
                            SpotId = spot.Id,

                        };
                        tempImages.Add(img);
                    }
                    _context.Images.AddRange(tempImages);
                }
            }
            var touristSpot = new District()
            {
                Id = spot.Id,
                Name = spot.Name,             
                Description = spot.Description,
                Images = null,
                Status = Enums.Status.Active,

            };
            _context.Entry(touristSpot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return touristSpot.Id;


        }
    }
}

