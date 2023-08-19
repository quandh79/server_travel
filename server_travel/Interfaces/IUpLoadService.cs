namespace server_travel.Interfaces
{
    public interface IUpLoadService
    {
      public  Task<string> UploadImageAsync(IFormFile image);
    }
}
