namespace server_travel.Dtos.District
{
    public class UpdateDistrictRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public IEnumerable<int> images { get; set; }
        public IEnumerable<IFormFile> files { get; set; }
    }
}
