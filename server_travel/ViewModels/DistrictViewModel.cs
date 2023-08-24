using server_travel.Entities;
using server_travel.Enums;
using server_travel.Models;

namespace server_travel.ViewModels
{
    public class DistrictViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual ICollection<Touristspot> Touristspots { get; set; } = new List<Touristspot>();
        public Status Status { get; set; }
    }
}
