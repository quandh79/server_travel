using server_travel.Entities;
using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Models
{
    public class TourViewModel
    {
        public int Id { get; set; }

        public int? SpotId { get; set; }

        public DateTime? TravelDate { get; set; }

        public int? Duration { get; set; }
        public decimal? Price { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        public string? Description { get; set; }

        public virtual Touristspot? Spot { get; set; }
        [DefaultValue(Status.Active)]
        public Status Status { get; set; }
    }
}
