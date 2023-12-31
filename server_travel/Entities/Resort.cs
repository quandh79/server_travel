﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using server_travel.Enums;

namespace server_travel.Entities;

public partial class Resort
{
    public int Id { get; set; }

    public int? SpotId { get; set; }

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public string? Cacilities { get; set; }

    public string? Address { get; set; }
    public string? ContactNumber { get; set; }
    public decimal? Price { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    public virtual ICollection<Room> Room { get; set; } = new List<Room>();
    public virtual Touristspot? Spot { get; set; }
    public int? DistrictId { get; set; }
    public virtual District? District { get; set; }
    [DefaultValue(Status.Active)]
    public Status Status { get; set; }
}
