using System.ComponentModel.DataAnnotations;

namespace server_travel.Entities
{
    public class TravelPlan
    {
        [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TourId { get; set; }
        public virtual Tour? Tour { get; set; }
    }
}
