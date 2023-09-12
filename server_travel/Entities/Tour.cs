using System;
using System.Collections.Generic;
using System.ComponentModel;
using server_travel.Enums;

namespace server_travel.Entities;

public partial class Tour
{
    public int Id { get; set; }

    public int? SpotId { get; set; }
    public string Name { get; set; }

    public DateTime? TravelDate { get; set; }
    public string? Duration { get; set; }

    public string? TravelType { get; set; }
    public int? Person { get; set; }
    public int? Sale { get; set; }
    public int? Price { get; set; }
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    public virtual ICollection<TravelPlan> TravelPlans { get; set; } = new List<TravelPlan>();
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public string? Description { get; set; }
    public int? DistrictId { get; set; }
    public virtual District? District { get; set; }
    public virtual Touristspot? Spot { get; set; }
    [DefaultValue(Status.Active)]
    public Status Status { get; set; }
}
