using server_travel.Entities;
using server_travel.Exceptions;
using server_travel.Interfaces;

namespace server_travel.Services
{
    public class UploadService : IUpLoadService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly TravelApiContext _context;
        public UploadService(IHttpContextAccessor httpContextAccessor, TravelApiContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public async Task<string> UploadImageAsync(IFormFile image)
        {
            if (image == null || image.Length <= 0)
            {
                throw new TravelException("Không tìm thấy hình ảnh.");
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var uploadPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var httpRequest = _httpContextAccessor.HttpContext.Request;
            var imageUrl = $"{httpRequest.Scheme}://{httpRequest.Host}/uploads/{fileName}";
            
            
            return imageUrl;
        }

    
    }
}
