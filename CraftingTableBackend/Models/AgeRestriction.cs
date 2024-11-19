using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class AgeRestriction
{
    public int Id { get; set; }

    public string AgeRestriction1 { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
