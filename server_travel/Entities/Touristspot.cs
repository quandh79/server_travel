using System;
using System.Collections.Generic;
using System.ComponentModel;
using server_travel.Enums;

namespace server_travel.Entities;

public partial class Touristspot
{
    public int Id { get; set; }
    public int? DistrictId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string? Description { get; set; }

    [DefaultValue(Status.Active)]
    public Status Status { get; set; }
    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<Resort> Resorts { get; set; } = new List<Resort>();

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    public virtual District? District { get; set; }

}
