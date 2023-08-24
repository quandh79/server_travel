using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Entities
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual ICollection<Touristspot> Touristspots { get; set; } = new List<Touristspot>();
        [DefaultValue(Status.Active)]
        public Status Status { get; set; }

    }
}
