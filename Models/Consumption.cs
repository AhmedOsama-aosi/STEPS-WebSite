using System;
using System.Collections.Generic;

namespace StepsWebApp.Models;

public partial class Consumption
{
    public int UserId { get; set; }

    public string? Time { get; set; }

    public DateTime? Date { get; set; }

    public double? Consume { get; set; }
}
