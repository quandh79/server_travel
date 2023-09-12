using server_travel.Entities;
using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Dtos.Hotel
{
    public class HotelCreateRequest
    {
       // public int Id { get; set; }

        public int? SpotId { get; set; }

        public string Name { get; set; } = null!;

        public string? Location { get; set; }

        public int? Rating { get; set; }

        public string? Address { get; set; }

        public string? ContactNumber { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public IEnumerable<IFormFile> images { get; set; }

        //public virtual Touristspot? Spot { get; set; }
        //[DefaultValue(Status.Active)]
        //public Status Status { get; set; }
    }
}
