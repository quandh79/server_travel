using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Dtos.Hotel
{
    public class HotelUpdateRequest
    {
         public int Id { get; set; }

        public int? SpotId { get; set; }

        public string Name { get; set; } = null!;

        public string? Location { get; set; }

        public int? Rating { get; set; }

        public string? Address { get; set; }

        public string? ContactNumber { get; set; }

        public IEnumerable<int> images { get; set; }
        public IEnumerable<IFormFile> files { get; set; }

        //public virtual Touristspot? Spot { get; set; }
        [DefaultValue(Status.Active)]
        public Status Status { get; set; }
    }
}
