using server_travel.Entities;
using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Dtos.Vehicle
{
    public class CreateVehicleRequest
    {

        public int? TourId { get; set; }

        public string Name { get; set; } = null!;

        public string? Type { get; set; }
        public decimal? Price { get; set; }


        public string? Description { get; set; }
        public IEnumerable<IFormFile> images { get; set; }



        // public Status Status { get; set; }
    }
}
