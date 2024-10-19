using System;
using System.Collections.Generic;

namespace JobVisionTest.Domain.Entities;

public partial class UserDeatali
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public virtual User? User { get; set; }
}
