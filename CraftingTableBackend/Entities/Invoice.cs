using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateOnly CreationDate { get; set; }

    public int Total { get; set; }

    public int Completed { get; set; }

    public int SubscriptionTier { get; set; }

    public int SubscriptionType { get; set; }

    public virtual User User { get; set; } = null!;
}
