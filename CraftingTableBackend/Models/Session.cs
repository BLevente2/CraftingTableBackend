using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class Session
{
    public int Id { get; set; }

    public int HostUser { get; set; }

    public int Game { get; set; }

    public string SessionJoinToken { get; set; } = null!;

    public DateOnly SessionStart { get; set; }

    public int SessionEnded { get; set; }

    public int SessionVisiblility { get; set; }

    public int WinnerUser { get; set; }

    public string SessionAssetsToken { get; set; } = null!;

    public DateOnly? SessionEnd { get; set; }

    public virtual Game GameNavigation { get; set; } = null!;

    public virtual User HostUserNavigation { get; set; } = null!;

    public virtual ICollection<SessionConnection> SessionConnections { get; set; } = new List<SessionConnection>();

    public virtual SessionVisibility SessionVisiblilityNavigation { get; set; } = null!;

    public virtual User WinnerUserNavigation { get; set; } = null!;
}
