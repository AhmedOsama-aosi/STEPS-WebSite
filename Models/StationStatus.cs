using System;
using System.Collections.Generic;

namespace StepsWebApp.Models;

public partial class StationStatus
{
    public TimeSpan? Time { get; set; }

    public DateTime? Date { get; set; }

    public int? SystemId { get; set; }

    public int? TempDegree { get; set; }

    public string? CloudStatus { get; set; }

    public int? WindSpeed { get; set; }

    public string? WindDirection { get; set; }

    public string? SunPostion { get; set; }

    public string? SolarAngel { get; set; }

    public double? EnergyProduction { get; set; }

    public double? EnergyConsumption { get; set; }

    public int Id { get; set; }

    public virtual StationInfo? System { get; set; }
}
