using System;
using System.Collections.Generic;

namespace CraftingTableBackend.Models;

public partial class User
{
    public int Id { get; set; }

    public string HashedPassword { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public int UseTwoFactor { get; set; }

    public int? TwoFactorType { get; set; }

    public string? TwoFactorToken { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateOnly BirthDate { get; set; }

    public int SubscriptionTier { get; set; }

    public int? SubscriptionType { get; set; }

    public string? SubscriptionToken { get; set; }

    public DateOnly? FirstSubscriptionDate { get; set; }

    public DateOnly? LastSubscriptionDate { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string PrivateUsername { get; set; } = null!;

    public string? PublicUsername { get; set; }

    public string? InviteCode { get; set; }

    public int LoginStatus { get; set; }

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual ICollection<FriendRequest> FriendRequestReceiverNavigations { get; set; } = new List<FriendRequest>();

    public virtual ICollection<FriendRequest> FriendRequestSenderNavigations { get; set; } = new List<FriendRequest>();

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual LoginStatus LoginStatusNavigation { get; set; } = null!;

    public virtual ICollection<SessionConnection> SessionConnections { get; set; } = new List<SessionConnection>();

    public virtual ICollection<Session> SessionHostUserNavigations { get; set; } = new List<Session>();

    public virtual ICollection<Session> SessionWinnerUserNavigations { get; set; } = new List<Session>();

    public virtual TwoFactorType? TwoFactorTypeNavigation { get; set; }

    public virtual ICollection<UserFriend> UserFriendFriends { get; set; } = new List<UserFriend>();

    public virtual ICollection<UserFriend> UserFriendUsers { get; set; } = new List<UserFriend>();
}
