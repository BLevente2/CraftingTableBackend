using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class TwoFactorType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
