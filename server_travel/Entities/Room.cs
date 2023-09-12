using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int? HotelId { get; set; }
        public int? ResortId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Sale { get; set; }
        public int? Price { get; set; }
        public int? Slot { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual Hotel? Hotel { get; set; }
        public virtual Resort? Resort { get; set; }


        [DefaultValue(Status.Active)]
        public Status Status { get; set; }

    }
}
