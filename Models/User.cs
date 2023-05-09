using System;
using System.Collections.Generic;

namespace StepsWebApp.Models;

public partial class User
{
    public static User? theUser { get; set; }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<StationInfo> StationInfos { get; set; } = new List<StationInfo>();
}
