using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class FriendRequestStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<FriendRequest> FriendRequests { get; set; } = new List<FriendRequest>();
}
