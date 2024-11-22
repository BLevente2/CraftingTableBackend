using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class UserFavourite
{
    public int Id { get; set; }

    public int GamePublicProfileId { get; set; }

    public int UserId { get; set; }

    public DateOnly BecameFavourite { get; set; }

    public virtual GamePublicProfile GamePublicProfile { get; set; } = null!;
}
