using server_travel.Entities;
using server_travel.Enums;

namespace server_travel.Models
{
    public class TourestSpotViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string? Description { get; set; }
        public virtual ICollection<Resort> Resorts { get; set; } = new List<Resort>();
        public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
        public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();


        public Status status { get; set; }
    }
}
