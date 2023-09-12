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
                Location = spot.Location,
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
                .Include(t=>t.Touristspots).Where(x => x.Status == Status.Active)
                .Include(h => h.Hotels).Where(x => x.Status == Status.Active)
                .Include(r => r.Restaurants).Where(x => x.Status == Status.Active)
                .Include(rs => rs.Resorts).Where(x => x.Status == Status.Active)
                 .Select(rs => new DistrictViewModel
                 {
                     Id = rs.Id,
                     Name = rs.Name,
                     Location = rs.Location,
                     Description = rs.Description,
                     Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
                     Touristspots= rs.Touristspots.Where(p => p.Status == Status.Active).ToList(),
                     Hotels= rs.Hotels.Where(p => p.Status == Status.Active).ToList(),
                     Resorts= rs.Resorts.Where(p => p.Status == Status.Active).ToList(),
                     Restaurants= rs.Restaurants.Where(p => p.Status == Status.Active).ToList(),
                     Status = rs.Status,
                 });
            return await data.ToListAsync();
        }

        public async Task<List<DistrictViewModel>> GetAllPaging(int? limit, int? page)
        {
            limit = limit != null ? limit : 10;
            page = page != null ? page : 1;
            int offset = (int)((page - 1) * limit);
            var data = _context.Districts.Include(img => img.Images).Where(x => x.Status == Status.Active)
                 .Include(t => t.Touristspots).Where(x => x.Status == Status.Active)
                 .Include(h => h.Hotels).Where(x => x.Status == Status.Active)
                 .Include(r => r.Restaurants).Where(x => x.Status == Status.Active)
                 .Include(rs => rs.Resorts).Where(x => x.Status == Status.Active)
                  .Select(rs => new DistrictViewModel
                  {
                      Id = rs.Id,
                      Name = rs.Name,
                      Location = rs.Location,
                      Description = rs.Description,
                      Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
                      Touristspots = rs.Touristspots.Where(p => p.Status == Status.Active).ToList(),
                      Hotels = rs.Hotels.Where(p => p.Status == Status.Active).ToList(),
                      Resorts = rs.Resorts.Where(p => p.Status == Status.Active).ToList(),
                      Restaurants = rs.Restaurants.Where(p => p.Status == Status.Active).ToList(),
                      Status = rs.Status,
                  });
            return await data.Skip(offset).Take((int)limit).ToListAsync();
        }

        public async Task<DistrictViewModel> Get_By_Id(int id)
        {
            var spot = await _context.Districts.Include(img => img.Images).Where(x => x.Status == Status.Active)
                .Include(t => t.Touristspots)
                    .ThenInclude(ts => ts.Hotels.Where(h => h.Status == Status.Active)) // Include Hotels của TouristSpots có Status.Active
                    .Include(t => t.Touristspots)
                        .ThenInclude(ts => ts.Resorts.Where(r => r.Status == Status.Active)) // Include Resorts của TouristSpots có Status.Active
                    .Include(t => t.Touristspots)
                        .ThenInclude(ts => ts.Restaurants.Where(rr => rr.Status == Status.Active)) // Include Restaurants của TouristSpots có Status.Active
                    .Include(t => t.Touristspots)
                        .ThenInclude(ts => ts.Tours.Where(t => t.Status == Status.Active)) // Include Tours của TouristSpots có Status.Active
                    .Where(x => x.Status == Status.Active)
                .Include(h => h.Hotels)
                .Include(r => r.Restaurants)
                .Include(rs => rs.Resorts)
                .Select(rs => new DistrictViewModel()
            {
                Id = rs.Id,
                Name = rs.Name,
                    Location = rs.Location,
                    Description = rs.Description,
                Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
                Touristspots = rs.Touristspots.Where(p => p.Status == Status.Active).ToList(),
                Hotels = rs.Hotels.Where(p => p.Status == Status.Active).ToList(),
                Resorts = rs.Resorts.Where(p => p.Status == Status.Active).ToList(),
                Restaurants = rs.Restaurants.Where(p => p.Status == Status.Active).ToList(),
                Status = rs.Status,
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = spot;

            return temp;
        }

        public async Task<int> Update(int id,UpdateDistrictRequest spot)

        {
            if (spot.images != null)
            {
                var findSpot = await _context.Districts.Include(img => img.Images).Select(se => new
                {
                    id = se.Id,
                    Image = se.Images.Where(e => e.Status == Status.Active).ToList()
                }
                ).FirstOrDefaultAsync(p => p.id == id);
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
                            DistrictId = findSpot.id,

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
               ).FirstOrDefaultAsync(p => p.id == id);
                foreach (var image in findSpot.Image)
                {
                  
                    
                        image.Status = Status.InActive;
                        _context.Entry(image).State = EntityState.Modified;
                    
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
                            DistrictId = findSpot.id,

                        };
                        tempImages.Add(img);
                    }
                    _context.Images.AddRange(tempImages);
                }
            }
            var touristSpot = new District()
            {
                Id = id,
                Name = spot.Name,             
                Description = spot.Description,
                Location = spot.Location,
                Images = null,
                Status = Enums.Status.Active,

            };
            _context.Entry(touristSpot).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return touristSpot.Id;


        }

        public async Task<List<DistrictViewModel>> SearchByName(string name)
        {
            var data = _context.Districts.Include(img => img.Images)
                .Include(t => t.Touristspots).ThenInclude(ts => ts.Images.Where(h => h.Status == Status.Active))
                .Include(h => h.Hotels)
                .Include(r => r.Restaurants)
                .Include(rs => rs.Resorts)
                .Where(x => x.Status == Status.Active && x.Name.Contains(name))
                .Select(rs => new DistrictViewModel
                {
                    Id = rs.Id,
                    Name = rs.Name,
                    Location = rs.Location,
                    Description = rs.Description,
                    Images = rs.Images.Where(p => p.Status == Status.Active).ToList(),
                    Touristspots = rs.Touristspots.Where(p => p.Status == Status.Active).ToList(),
                    Hotels = rs.Hotels.Where(p => p.Status == Status.Active).ToList(),
                    Resorts = rs.Resorts.Where(p => p.Status == Status.Active).ToList(),
                    Restaurants = rs.Restaurants.Where(p => p.Status == Status.Active).ToList(),
                    Status = rs.Status,
                });

            return await data.ToListAsync();
        }

        public async Task<List<object>> Search(string name)
        {
            var districtData = await _context.Districts.Include(i=>i.Images)
                .Where(x => x.Status == Status.Active && x.Name.Contains(name))
                .ToListAsync();

            var touristSpotData = await _context.Touristspots.Include(i=>i.Images)
                .Where(x => x.Status == Status.Active && x.Name.Contains(name))
                .ToListAsync();

            var results = new List<object>();

            foreach (var district in districtData)
            {
                results.Add(new DistrictViewModel
                {
                    Id = district.Id,
                    Name = district.Name,
                    Description = district.Description,
                    Images = district.Images.Where(i=>i.Status == Status.Active).ToList()
                    
                });
            }

            foreach (var touristSpot in touristSpotData)
            {
                results.Add(new TourestSpotViewModel
                {
                    Id = touristSpot.Id,
                    Name = touristSpot.Name,
                    Description = touristSpot.Description,
                    Images = touristSpot.Images.Where(i=>i.Status == Status.Active).ToList()

                });
            }

            return results;
        }
    }
}

