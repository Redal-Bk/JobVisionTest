using System;
using System.Collections.Generic;

namespace JobVisionTest.Domain.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? ProfileImageUrl { get; set; }

    public string? Name { get; set; }

    public string? Family { get; set; }

    public virtual ICollection<UserDeatali> UserDeatalis { get; set; } = new List<UserDeatali>();
}
