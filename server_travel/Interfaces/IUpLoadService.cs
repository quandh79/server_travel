using server_travel.Entities;
using server_travel.Models;

namespace server_travel.Interfaces
{
    public interface IUpLoadService
    {
      public  Task<string> UploadImageAsync(IFormFile image);
      public Task<Image> UploadImageGallery(IFormFile image);
        public Task<List<ImageViewModel>> GetImageGallery();

    }
}
