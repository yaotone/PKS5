using System;
using System.Collections.Generic;

namespace pks5_core;

public partial class Mark
{
    public int Id { get; set; }

    public string Subject { get; set; } = null!;

    public int Mark1 { get; set; }
    public string Semester { get; set; }
}
