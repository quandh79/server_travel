using server_travel.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace server_travel.Entities
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }

        [DefaultValue(Status.Active)]
        public Status Status { get; set; }
    }
}
