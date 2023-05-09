using System;
using System.Collections.Generic;

namespace StepsWebApp.Models;

public partial class Article
{
    public int Id { get; set; }

    public string? PhotoLink { get; set; }

    public string? Discription { get; set; }

    public string? Btn { get; set; }
}
