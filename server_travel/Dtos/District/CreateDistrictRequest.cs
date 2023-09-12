using server_travel.Enums;

namespace server_travel.Dtos.District
{
    public class CreateDistrictRequest
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Location { get; set; }

        public IEnumerable<IFormFile> images { get; set; }
    }
}
