using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class FriendRequest
{
    public int Id { get; set; }

    public int Sender { get; set; }

    public int Receiver { get; set; }

    public DateOnly SendDate { get; set; }

    public int RequestStatus { get; set; }

    public virtual User ReceiverNavigation { get; set; } = null!;

    public virtual FriendRequestStatus RequestStatusNavigation { get; set; } = null!;

    public virtual User SenderNavigation { get; set; } = null!;
}
