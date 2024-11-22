using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class GameVersion
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public int PublicProfileId { get; set; }

    public string VersionName { get; set; } = null!;

    public string ChangeLog { get; set; } = null!;

    public virtual Game Game { get; set; } = null!;

    public virtual ICollection<GameIssue> GameIssues { get; set; } = new List<GameIssue>();

    public virtual ICollection<GamePublicProfile> GamePublicProfiles { get; set; } = new List<GamePublicProfile>();

    public virtual GamePublicProfile PublicProfile { get; set; } = null!;
}
