using server_travel.Entities;
using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        public int? TourId { get; set; }

        public string Name { get; set; } = null!;

        public string? Type { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        public string? Description { get; set; }
        public Status Status { get; set; }
    }
}
