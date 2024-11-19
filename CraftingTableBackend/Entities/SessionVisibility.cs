using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class SessionVisibility
{
    public int Id { get; set; }

    public string Visibility { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
