using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.Tour;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Exceptions;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Services
{
    public class ManageTourService : IManageTour
    {
        private readonly IUpLoadService _upLoadService;
        private readonly TravelApiContext _context;
        public ManageTourService(IUpLoadService upLoadService, TravelApiContext context)
        {
            _upLoadService = upLoadService;
            _context = context;
        }
        public async Task<int> Create(TourCreateRequest request)
        {
            var tourImage = new List<Image>();
            foreach (var image in request.images)
            {
                if (image == null || image.Length <= 0)
                {
                    throw new TravelException("Không tìm thấy hình ảnh.");
                }
                var imageUrl = await _upLoadService.UploadImageAsync(image);
                tourImage.Add(new Image
                {
                    ImageUrl = imageUrl,
                    Status = Status.Active
                });

            }
            var tour = new Tour()
            {
                SpotId = request.SpotId,
                TravelDate = request.TravelDate,
                Duration = request.Duration,
                Price = request.Price,
                Description = request.Description,
                Status = Enums.Status.Active,
                Images = tourImage,
            };

            _context.Tours.Add(tour);
            await _context.SaveChangesAsync();


            return tour.Id;
        }

        public async Task<int> Delete(int id)
        {
            var tour = await _context.Tours.FindAsync(id);
            if (tour == null)
            {
                throw new TravelException("khong tim thay TouristSpot");
            }
            tour.Status = Status.InActive;
            _context.Entry(tour).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TourViewModel>> GetAll()
        {
            var data = _context.Tours.Include(img => img.Images).Where(x => x.Status == Status.Active)
                 .Select(rs => new TourViewModel
                 {
                     Id = rs.Id,
                     SpotId = rs.SpotId,
                     TravelDate = rs.TravelDate,
                     Duration = rs.Duration,
                     Price = rs.Price,
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
                TravelDate = rs.TravelDate,
                Duration = rs.Duration,
                Price = rs.Price,
                Description = rs.Description,
                Images = rs.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = rs.Status
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = restaurant;

            return temp;
        }

        public async Task<int> Update(TourUpdateRequest request)

        {
            if (request.images != null)
            {
                var findRestaurant = await _context.Tours.Include(img => img.Images).Select(se => new
                {
                    id = se.Id,
                    Image = se.Images.Where(e => e.Status == Status.Active).ToList()
                }
                ).FirstOrDefaultAsync(p => p.id == request.Id);
                foreach (var image in findRestaurant.Image)
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
                var findRestaurant = await _context.Tours.Include(img => img.Images).Select(se => new
                {
                    id = se.Id,
                    Image = se.Images.Where(e => e.Status == Status.Active).ToList()
                }
               ).FirstOrDefaultAsync(p => p.id == request.Id);
                foreach (var image in findRestaurant.Image)
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
            var tour = new Tour()
            {
                SpotId = request.SpotId,
               TravelDate = request.TravelDate,
               Duration = request.Duration,

                Price = request.Price,
                Description = request.Description,
                Status = Enums.Status.Active,
                Images = null,


            };
            _context.Entry(tour).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return tour.Id;


        }
    }
}
