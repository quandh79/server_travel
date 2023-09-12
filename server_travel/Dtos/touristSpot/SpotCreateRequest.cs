using Microsoft.AspNetCore.Http;
using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Dtos.touristSpot
{
    public class SpotCreateRequest
    {
        public int? DistrictId { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string? Description { get; set; }
       // [DefaultValue(Status.Active)]
        //public Status Status { get; set; }
        public IEnumerable<IFormFile>? images { get; set; }
    }
}
