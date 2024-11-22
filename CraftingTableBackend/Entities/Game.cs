using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class Game
{
    public int Id { get; set; }

    public int CreatorUser { get; set; }

    public int GameVisiblility { get; set; }

    public int AgeRestricted { get; set; }

    public int AgeRestriction { get; set; }

    public string GamePreview { get; set; } = null!;

    public string GameAssetsToken { get; set; } = null!;

    public string GameScript { get; set; } = null!;

    public virtual AgeRestriction AgeRestrictionNavigation { get; set; } = null!;

    public virtual User CreatorUserNavigation { get; set; } = null!;

    public virtual ICollection<GameVersion> GameVersions { get; set; } = new List<GameVersion>();

    public virtual GameVisibility GameVisiblilityNavigation { get; set; } = null!;

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
