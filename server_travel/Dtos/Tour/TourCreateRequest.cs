using server_travel.Entities;
using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Dtos.Tour
{
    public class TourCreateRequest
    {


        public int? SpotId { get; set; }

        public DateTime? TravelDate { get; set; }

        public int? Duration { get; set; }
        public decimal? Price { get; set; }
        public IEnumerable<IFormFile> images { get; set; }
        public string? Description { get; set; }
        [DefaultValue(Status.Active)]
        public Status Status { get; set; }
    }
}
