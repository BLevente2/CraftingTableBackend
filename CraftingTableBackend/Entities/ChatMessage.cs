using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class ChatMessage
{
    public int Id { get; set; }

    public int Session { get; set; }

    public int Sender { get; set; }

    public int? Answered { get; set; }

    public DateOnly SendDate { get; set; }

    public string Message { get; set; } = null!;

    public virtual ChatMessage? AnsweredNavigation { get; set; }

    public virtual ICollection<ChatMessage> InverseAnsweredNavigation { get; set; } = new List<ChatMessage>();

    public virtual User SenderNavigation { get; set; } = null!;

    public virtual Session SessionNavigation { get; set; } = null!;
}
