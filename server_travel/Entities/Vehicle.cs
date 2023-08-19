﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using server_travel.Enums;

namespace server_travel.Entities;

public partial class Vehicle
{
    public int Id { get; set; }

    public int? SpotId { get; set; }

    public string Name { get; set; } = null!;

    public string? Type { get; set; }

    public string? Description { get; set; }

    public virtual Touristspot? Spot { get; set; }
    [DefaultValue(Status.Active)]
    public Status Status { get; set; }
}