using System;
using System.Collections.Generic;

namespace DBFirst_Bus.Models;

public partial class Bus
{
    public string BusName { get; set; } = null!;

    public string? Route { get; set; }

    public string? Timing { get; set; }
}
