using System;
using System.Collections.Generic;

namespace pks5_core;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
