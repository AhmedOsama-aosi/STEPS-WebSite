using System;
using System.Collections.Generic;

namespace StepsWebApp.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Photo { get; set; }

    public string Discription { get; set; } = null!;

    public string? Link { get; set; }
}
