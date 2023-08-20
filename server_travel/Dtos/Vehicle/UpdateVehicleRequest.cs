using server_travel.Entities;
using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Dtos.Vehicle
{
    public class UpdateVehicleRequest
    {
        public int Id { get; set; }

        public int? SpotId { get; set; }

        public string Name { get; set; } = null!;

        public string? Type { get; set; }
        public decimal? Price { get; set; }


        public string? Description { get; set; }

        public Status Status { get; set; }
    }
}
