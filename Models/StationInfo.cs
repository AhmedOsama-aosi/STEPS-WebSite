using System;
using System.Collections.Generic;

namespace StepsWebApp.Models;

public partial class StationInfo
{
    public string? SolarPanelType { get; set; }

    public string? InverterType { get; set; }

    public string? BatteryType { get; set; }

    public int? SolarPanelCount { get; set; }

    public double? Space { get; set; }

    public string? Location { get; set; }

    public DateTime? InstallationDate { get; set; }

    public string? InstallationType { get; set; }

    public double? TotalAmpereNeed { get; set; }

    public double? BatteryCapacty { get; set; }

    public int? BattteryCount { get; set; }

    public DateTime? BatteryDate { get; set; }

    public int SystemId { get; set; }

    public int? UserId { get; set; }

    public double? EnergyNeed { get; set; }

    public virtual ICollection<StationStatus> StationStatuses { get; set; } = new List<StationStatus>();

    public virtual User? User { get; set; }
}
