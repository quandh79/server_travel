using Microsoft.AspNetCore.Http;
using server_travel.Enums;

namespace server_travel.Dtos.touristSpot
{
    public class SpotCreateRequest
    {
        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string? Description { get; set; }
        public Status Status { get; set; }
        public IEnumerable<IFormFile> images { get; set; }
    }
}
