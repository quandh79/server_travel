namespace server_travel.Dtos.Room
{
    public class CreateRoomRequest
    {
        public int? HotelId { get; set; }
        public int? ResortId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Sale { get; set; }
        public int? Price { get; set; }
        public int? Slot { get; set; }
        public IEnumerable<IFormFile> images { get; set; }

    }
}
