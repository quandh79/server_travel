using server_travel.Enums;

namespace server_travel.Dtos.touristSpot
{
    public class SpotUpdateRequest
    {
        public int Id { get; set; }
        public int? DistrictId { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string? Description { get; set; }
        public IEnumerable<int>? images { get; set; }
        public IEnumerable<IFormFile>? files { get; set; }

    }
}
