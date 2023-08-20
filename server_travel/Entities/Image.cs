using System;
using System.Collections.Generic;
using System.ComponentModel;
using server_travel.Enums;

namespace server_travel.Entities;

public partial class Image
{
    public int Id { get; set; }

    public int? SpotId { get; set; }

    public int? HotelId { get; set; }

    public int? ResortId { get; set; }

    public int? RestaurantId { get; set; }
    public int? TourId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Hotel? Hotel { get; set; }

    public virtual Resort? Resort { get; set; }

    public virtual Restaurant? Restaurant { get; set; }
    public virtual Tour? Tour { get; set; }


    public virtual Touristspot? Spot { get; set; }
    [DefaultValue(Status.Active)]
    public Status Status { get; set; }
}
