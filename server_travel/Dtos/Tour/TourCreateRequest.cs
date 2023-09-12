using server_travel.Entities;
using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Dtos.Tour
{
    public class TourCreateRequest
    {

        
        public int? SpotId { get; set; }
        public string Name { get; set; }

        public DateTime? TravelDate { get; set; }

        public string? Duration { get; set; }
        public int? Sale { get; set; }
        public int? Price { get; set; }
        public string? TravelType { get; set; }
        public int? Person { get; set; }
        public IEnumerable<IFormFile> images { get; set; }
        public string? Description { get; set; }
        //[DefaultValue(Status.Active)]
        //public Status Status { get; set; }
    }
}
