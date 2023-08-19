using System;
using System.Collections.Generic;
using System.ComponentModel;
using server_travel.Enums;

namespace server_travel.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? Birthday { get; set; }

    public string? RoleTitle { get; set; }

    public string? JobTitle { get; set; }

    public string? Token { get; set; }

    public string? Tel { get; set; }
    [DefaultValue(Status.Active)]
    public Status Status { get; set; }
}
