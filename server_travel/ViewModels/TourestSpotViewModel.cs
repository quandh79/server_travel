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
        public virtual ICollection<Image> Images { get; set; }
        public Status status { get; set; }
    }
}
