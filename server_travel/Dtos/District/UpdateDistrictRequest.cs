namespace server_travel.Dtos.District
{
    public class UpdateDistrictRequest
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Location { get; set; }

        public IEnumerable<int>? images { get; set; }
        public IEnumerable<IFormFile>? files { get; set; }
    }
}
