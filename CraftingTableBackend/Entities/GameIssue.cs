using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class GameIssue
{
    public int Id { get; set; }

    public int Fixed { get; set; }

    public DateOnly DetectionDate { get; set; }

    public string IssueName { get; set; } = null!;

    public string IssueDetails { get; set; } = null!;

    public int GameVersionId { get; set; }

    public virtual GameVersion GameVersion { get; set; } = null!;
}
