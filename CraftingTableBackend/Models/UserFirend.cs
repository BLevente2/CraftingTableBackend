using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class UserFirend
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int FriendId { get; set; }

    public DateOnly Friended { get; set; }

    public string Nickname { get; set; } = null!;

    public virtual User Friend { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
