using Microsoft.EntityFrameworkCore;
using server_travel.Dtos.Hotel;
using server_travel.Dtos.Restaurant;
using server_travel.Entities;
using server_travel.Enums;
using server_travel.Exceptions;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Services
{
    public class ManageRestaurantService : IManageRestaurant
    {
        private readonly IUpLoadService _upLoadService;
        private readonly TravelApiContext _context;
        public ManageRestaurantService(IUpLoadService upLoadService, TravelApiContext context)
        {
            _upLoadService = upLoadService;
            _context = context;
        }
        public async Task<int> Create(RestaurantCreateRequest request)
        {
            var restaurantImage = new List<Image>();
            foreach (var image in request.images)
            {
                if (image == null || image.Length <= 0)
                {
                    throw new TravelException("Không tìm thấy hình ảnh.");
                }
                var imageUrl = await _upLoadService.UploadImageAsync(image);
                restaurantImage.Add(new Image
                {
                    ImageUrl = imageUrl,
                    Status = Status.Active
                });

            }
            var restaurant = new Restaurant()
            {
                SpotId = request.SpotId,
                Name = request.Name,
                Location = request.Location,
                CuisineType = request.CuisineType,
                Address = request.Address,
                ContactNumber = request.ContactNumber,
                Price = request.Price,
                Description = request.Description,
                Status = Enums.Status.Active,
                Images = restaurantImage,
            };

            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();


            return restaurant.Id;
        }

        public async Task<int> Delete(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                throw new TravelException("khong tim thay TouristSpot");
            }
            restaurant.Status = Status.InActive;
            _context.Entry(restaurant).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<List<RestaurantViewModel>> GetAll()
        {
            var data = _context.Restaurants.Include(img => img.Images).Where(x => x.Status == Status.Active)
                 .Select(rs => new RestaurantViewModel
                 {
                     Id = rs.Id,
                     SpotId = rs.SpotId,
                     Name = rs.Name,
                     Location = rs.Location,
                     CuisineType = rs.CuisineType,
                     Address = rs.Address,
                     ContactNumber = rs.ContactNumber,
                     Price = rs.Price,
                     Description = rs.Description,
                     Images = rs.Images.Where(i => i.Status == Status.Active).ToList(),
                     Status = rs.Status
                 });
            return await data.ToListAsync();
        }

        public async Task<RestaurantViewModel> Get_By_Id(int id)
        {
            var restaurant = await _context.Restaurants.Include(img => img.Images).Select(s => new RestaurantViewModel()
            {
                Id = s.Id,
                SpotId = s.SpotId,
                Name = s.Name,
                Location = s.Location,
                CuisineType = s.CuisineType,
                Address = s.Address,
                ContactNumber = s.ContactNumber,
                Price = s.Price,
                Description = s.Description,
                Images = s.Images.Where(i => i.Status == Status.Active).ToList(),
                Status = s.Status
            }).FirstOrDefaultAsync(x => x.Id == id);
            var temp = restaurant;

            return temp;
        }

        public async Task<int> Update(RestaurantUpdateRequest request)

        {
            if (request.images != null)
            {
                var findRestaurant = await _context.Restaurants.Include(img => img.Images).Select(se => new
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
                var findRestaurant = await _context.Restaurants.Include(img => img.Images).Select(se => new
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
            var restaurant = new Restaurant()
            {
                SpotId = request.SpotId,
                Name = request.Name,
                Location = request.Location,
                CuisineType = request.CuisineType,
                Address = request.Address,
                ContactNumber = request.ContactNumber,
                Price = request.Price,
                Description = request.Description,
                Status = Enums.Status.Active,
                Images = null,


            };
            _context.Entry(restaurant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return restaurant.Id;


        }
    }
}
