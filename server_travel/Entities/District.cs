﻿using server_travel.Enums;
using System.ComponentModel;

namespace server_travel.Entities
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        public virtual ICollection<Resort> Resorts { get; set; } = new List<Resort>();

        public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

        public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>(); public virtual ICollection<Touristspot> Touristspots { get; set; } = new List<Touristspot>();
        [DefaultValue(Status.Active)]
        public Status Status { get; set; }

    }
}
