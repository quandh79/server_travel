using server_travel.Entities;
using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Dtos.Tour
{
    public class TourUpdateRequest
    {
        public int Id { get; set; }

        public int? SpotId { get; set; }

        public DateTime? TravelDate { get; set; }

        public int? Duration { get; set; }
        public decimal? Price { get; set; }
        public IEnumerable<int> images { get; set; }
        public IEnumerable<IFormFile> files { get; set; }

        public string? Description { get; set; }
        [DefaultValue(Status.Active)]
        public Status Status { get; set; }
    }
}
