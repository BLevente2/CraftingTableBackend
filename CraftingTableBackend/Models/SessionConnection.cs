using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class SessionConnection
{
    public int Id { get; set; }

    public int Session { get; set; }

    public int User { get; set; }

    public DateOnly ConnectionDate { get; set; }

    public int ConnectionStatus { get; set; }

    public virtual Session SessionNavigation { get; set; } = null!;

    public virtual User UserNavigation { get; set; } = null!;
}
