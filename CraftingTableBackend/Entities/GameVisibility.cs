using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class GameVisibility
{
    public int Id { get; set; }

    public string Visibility { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
