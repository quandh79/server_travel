using server_travel.Entities;
using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Models
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }

        public int? SpotId { get; set; }

        public string Name { get; set; } = null!;

        public string? Location { get; set; }

        public string? CuisineType { get; set; }

        public string? Address { get; set; }

        public string? ContactNumber { get; set; }
        public decimal? Price { get; set; }

        public string? Description { get; set; }


        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        public virtual Touristspot? Spot { get; set; }
        [DefaultValue(Status.Active)]
        public Status Status { get; set; }
    }
}
