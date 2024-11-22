using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class GamePublicProfile
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly? ShareDate { get; set; }

    public DateOnly? LastModifiedDate { get; set; }

    public string AssetsToken { get; set; } = null!;

    public int NumOfViews { get; set; }

    public int NumOfStars { get; set; }

    public int NumOfReviews { get; set; }

    public int LastVersion { get; set; }

    public virtual ICollection<GameVersion> GameVersions { get; set; } = new List<GameVersion>();

    public virtual GameVersion LastVersionNavigation { get; set; } = null!;

    public virtual ICollection<UserFavourite> UserFavourites { get; set; } = new List<UserFavourite>();
}
