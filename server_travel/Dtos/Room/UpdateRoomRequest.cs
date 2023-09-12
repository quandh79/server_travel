namespace server_travel.Dtos.Room
{
    public class UpdateRoomRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Sale { get; set; }
        public int? Price { get; set; }
        public int? Slot { get; set; }
        public IEnumerable<int>? images { get; set; }
        public IEnumerable<IFormFile>? files { get; set; }
    }
}
