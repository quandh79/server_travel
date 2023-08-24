using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Models
{
    public class ImageViewModel
    {
        public int id { get; set; }
        public string urlImage { get; set; }
        [DefaultValue(Status.Active)]
        public Status status { get; set; }
    }
}
