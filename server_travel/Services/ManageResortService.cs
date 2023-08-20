using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.Hotel;
using server_travel.Dtos.Resort;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Exceptions;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Services
{
    public class ManageResortService : IManageResort
    {
        private readonly TravelApiContext _context;
        private readonly IUpLoadService _upLoadService;
        public ManageResortService(TravelApiContext context, IUpLoadService uploadService )
        {
            _context = context;
            _upLoadService = uploadService;
        }
        public async Task<int> Create(ResortCreateRequest request)
        {
            var resortImages = new List<Image>();
            foreach (var image in request.images)
            {
                if (image == null || image.Length <= 0)
                {
                    throw new TravelException("Không tìm thấy hình ảnh.");
                }
                var imageUrl = await _upLoadService.UploadImageAsync(image);
                resortImages.Add(new Image
                {
                    ImageUrl = imageUrl,
                    Status = Status.Active
                });

            }
            var resort = new Resort()
            {
                SpotId = request.SpotId,
                Name = request.Name,
                Location = request.Location,
                Cacilities = request.Cacilities,
                Address = request.Address,
                ContactNumber = request.ContactNumber,
                Price = request.Price,
                Description = request.Description,
                Status = Enums.Status.Active,
                Images = resortImages,
            };

            _context.Resorts.Add(resort);
            await _context.SaveChangesAsync();


            return resort.Id;
        }

        public async Task<int> Delete(int id)
        {
            var resort = await _context.Resorts.FindAsync(id);
            if (resort == null)
            {
                throw new TravelException("khong tim thay resort");
            }
            resort.Status = Status.InActive;
            _context.Entry(resort).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ResortViewModel>> GetAll()
        {
            var data = _context.Resorts.Include(img => img.Images).Where(x => x.Status == Status.Active)
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
                     Images = rs.Images.Where(i => i.Status == Status.Active).ToList(),
                     Status = rs.Status
                 });
            return await data.ToListAsync();
        }

        public async Task<ResortViewModel> Get_By_Id(int id)
        {
            var resort = await _context.Resorts.Include(img => img.Images).Select(s => new ResortViewModel()
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
                Images = s.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = s.Status
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = resort;

            return temp;
        }

        public async Task<int> Update(ResortUpdateRequest request)

        {
            if (request.images != null)
            {
                var findResort = await _context.Resorts.Include(img => img.Images).Select(se => new
                {
                    id = se.Id,
                    Image = se.Images.Where(e => e.Status == Status.Active).ToList()
                }
                ).FirstOrDefaultAsync(p => p.id == request.Id);
                foreach (var image in findResort.Image)
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
                            SpotId = request.Id,

                        };
                        tempImages.Add(img);
                    }
                    _context.Images.AddRange(tempImages);
                }
            }
            else
            {
                var findSpot = await _context.Resorts.Include(img => img.Images).Select(se => new
                {
                    id = se.Id,
                    Image = se.Images.Where(e => e.Status == Status.Active).ToList()
                }
               ).FirstOrDefaultAsync(p => p.id == request.Id);
                foreach (var image in findSpot.Image)
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
                            SpotId = request.Id,

                        };
                        tempImages.Add(img);
                    }
                    _context.Images.AddRange(tempImages);
                }
            }
            var resort = new Resort()
            {
                SpotId = request.SpotId,
                Name = request.Name,
                Location = request.Location,
                Cacilities = request.Cacilities,
                Address = request.Address,
                ContactNumber = request.ContactNumber,
                Price = request.Price,
                Description = request.Description,
                Status = Enums.Status.Active,
                Images = null,


            };
            _context.Entry(resort).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return resort.Id;


        }

    }
}
