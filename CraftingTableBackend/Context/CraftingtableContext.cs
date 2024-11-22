using System;
using System.Collections.Generic;
using CraftingTableBackend.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace CraftingTableBackend.Context;

public partial class CraftingtableContext : DbContext
{
    public CraftingtableContext()
    {
    }

    public CraftingtableContext(DbContextOptions<CraftingtableContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgeRestriction> AgeRestrictions { get; set; }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<FriendRequest> FriendRequests { get; set; }

    public virtual DbSet<FriendRequestStatus> FriendRequestStatuses { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameIssue> GameIssues { get; set; }

    public virtual DbSet<GamePublicProfile> GamePublicProfiles { get; set; }

    public virtual DbSet<GameVersion> GameVersions { get; set; }

    public virtual DbSet<GameVisibility> GameVisibilities { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<LoginStatus> LoginStatuses { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<SessionConnection> SessionConnections { get; set; }

    public virtual DbSet<SessionVisibility> SessionVisibilities { get; set; }

    public virtual DbSet<TwoFactorType> TwoFactorTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFavourite> UserFavourites { get; set; }

    public virtual DbSet<UserFirend> UserFirends { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=craftingtable;user=root;ssl mode=none", ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AgeRestriction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("age_restriction");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AgeRestriction1)
                .HasColumnType("text")
                .HasColumnName("age_restriction");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chat_message");

            entity.HasIndex(e => e.Session, "chat");

            entity.HasIndex(e => e.Answered, "message_answered");

            entity.HasIndex(e => e.Sender, "message_sender");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Answered)
                .HasColumnType("int(11)")
                .HasColumnName("answered");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.SendDate).HasColumnName("send_date");
            entity.Property(e => e.Sender)
                .HasColumnType("int(11)")
                .HasColumnName("sender");
            entity.Property(e => e.Session)
                .HasColumnType("int(11)")
                .HasColumnName("session");

            entity.HasOne(d => d.AnsweredNavigation).WithMany(p => p.InverseAnsweredNavigation)
                .HasForeignKey(d => d.Answered)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("answered_message");

            entity.HasOne(d => d.SenderNavigation).WithMany(p => p.ChatMessages)
                .HasForeignKey(d => d.Sender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("message_sender");

            entity.HasOne(d => d.SessionNavigation).WithMany(p => p.ChatMessages)
                .HasForeignKey(d => d.Session)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("chat");
        });

        modelBuilder.Entity<FriendRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("friend_request");

            entity.HasIndex(e => e.RequestStatus, "freind_request_status_connection");

            entity.HasIndex(e => e.Receiver, "receiver_user");

            entity.HasIndex(e => e.Sender, "sender_user");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Receiver)
                .HasColumnType("int(11)")
                .HasColumnName("receiver");
            entity.Property(e => e.RequestStatus)
                .HasColumnType("int(11)")
                .HasColumnName("request_status");
            entity.Property(e => e.SendDate).HasColumnName("send_date");
            entity.Property(e => e.Sender)
                .HasColumnType("int(11)")
                .HasColumnName("sender");

            entity.HasOne(d => d.ReceiverNavigation).WithMany(p => p.FriendRequestReceiverNavigations)
                .HasForeignKey(d => d.Receiver)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("receiver_user");

            entity.HasOne(d => d.RequestStatusNavigation).WithMany(p => p.FriendRequests)
                .HasForeignKey(d => d.RequestStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("freind_request_status_connection");

            entity.HasOne(d => d.SenderNavigation).WithMany(p => p.FriendRequestSenderNavigations)
                .HasForeignKey(d => d.Sender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sender_user");
        });

        modelBuilder.Entity<FriendRequestStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("friend_request_status");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasColumnType("text")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game");

            entity.HasIndex(e => e.AgeRestriction, "age_restriction_type");

            entity.HasIndex(e => e.CreatorUser, "game_creator_connection");

            entity.HasIndex(e => e.GameVisiblility, "game_visiblility_type");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AgeRestricted)
                .HasColumnType("int(11)")
                .HasColumnName("age_restricted");
            entity.Property(e => e.AgeRestriction)
                .HasColumnType("int(11)")
                .HasColumnName("age_restriction");
            entity.Property(e => e.CreatorUser)
                .HasColumnType("int(11)")
                .HasColumnName("creator_user");
            entity.Property(e => e.GameAssetsToken)
                .HasColumnType("text")
                .HasColumnName("game_assets_token");
            entity.Property(e => e.GamePreview)
                .HasColumnType("text")
                .HasColumnName("game_preview");
            entity.Property(e => e.GameScript)
                .HasColumnType("text")
                .HasColumnName("game_script");
            entity.Property(e => e.GameVisiblility)
                .HasColumnType("int(11)")
                .HasColumnName("game_visiblility");

            entity.HasOne(d => d.AgeRestrictionNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.AgeRestriction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("age_restriction_type");

            entity.HasOne(d => d.CreatorUserNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.CreatorUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("game_creator_connection");

            entity.HasOne(d => d.GameVisiblilityNavigation).WithMany(p => p.Games)
                .HasForeignKey(d => d.GameVisiblility)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("game_visiblility_type");
        });

        modelBuilder.Entity<GameIssue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game_issue");

            entity.HasIndex(e => e.GameVersionId, "game_version_connection");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DetectionDate).HasColumnName("detection_date");
            entity.Property(e => e.Fixed)
                .HasColumnType("int(11)")
                .HasColumnName("fixed");
            entity.Property(e => e.GameVersionId)
                .HasColumnType("int(11)")
                .HasColumnName("game_version_id");
            entity.Property(e => e.IssueDetails)
                .HasColumnType("text")
                .HasColumnName("issue_details");
            entity.Property(e => e.IssueName)
                .HasColumnType("text")
                .HasColumnName("issue_name");

            entity.HasOne(d => d.GameVersion).WithMany(p => p.GameIssues)
                .HasForeignKey(d => d.GameVersionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("game_version_connection");
        });

        modelBuilder.Entity<GamePublicProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game_public_profile");

            entity.HasIndex(e => e.LastVersion, "last_verson_of_game");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AssetsToken)
                .HasColumnType("text")
                .HasColumnName("assets_token");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.LastModifiedDate).HasColumnName("last_modified_date");
            entity.Property(e => e.LastVersion)
                .HasColumnType("int(11)")
                .HasColumnName("last_version");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.NumOfReviews)
                .HasColumnType("int(11)")
                .HasColumnName("num_of_reviews");
            entity.Property(e => e.NumOfStars)
                .HasColumnType("int(11)")
                .HasColumnName("num_of_stars");
            entity.Property(e => e.NumOfViews)
                .HasColumnType("int(11)")
                .HasColumnName("num_of_views");
            entity.Property(e => e.ShareDate).HasColumnName("share_date");

            entity.HasOne(d => d.LastVersionNavigation).WithMany(p => p.GamePublicProfiles)
                .HasForeignKey(d => d.LastVersion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("last_verson_of_game");
        });

        modelBuilder.Entity<GameVersion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game_version");

            entity.HasIndex(e => e.GameId, "verson_of_game");

            entity.HasIndex(e => e.PublicProfileId, "verson_of_public_profile");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ChangeLog)
                .HasColumnType("text")
                .HasColumnName("change_log");
            entity.Property(e => e.GameId)
                .HasColumnType("int(11)")
                .HasColumnName("game_id");
            entity.Property(e => e.PublicProfileId)
                .HasColumnType("int(11)")
                .HasColumnName("public_profile_id");
            entity.Property(e => e.VersionName)
                .HasColumnType("text")
                .HasColumnName("version_name");

            entity.HasOne(d => d.Game).WithMany(p => p.GameVersions)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("verson_of_game");

            entity.HasOne(d => d.PublicProfile).WithMany(p => p.GameVersions)
                .HasForeignKey(d => d.PublicProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("verson_of_public_profile");
        });

        modelBuilder.Entity<GameVisibility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game_visibility");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Visibility)
                .HasColumnType("text")
                .HasColumnName("visibility");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("invoice");

            entity.HasIndex(e => e.UserId, "invoice_user");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Completed)
                .HasColumnType("int(11)")
                .HasColumnName("completed");
            entity.Property(e => e.CreationDate).HasColumnName("creation_date");
            entity.Property(e => e.SubscriptionTier)
                .HasColumnType("int(11)")
                .HasColumnName("subscription_tier");
            entity.Property(e => e.SubscriptionType)
                .HasColumnType("int(11)")
                .HasColumnName("subscription_type");
            entity.Property(e => e.Total)
                .HasColumnType("int(11)")
                .HasColumnName("total");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("invoice_user");
        });

        modelBuilder.Entity<LoginStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("login_status");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Status)
                .HasColumnType("text")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("session");

            entity.HasIndex(e => e.HostUser, "host");

            entity.HasIndex(e => e.Game, "session_game");

            entity.HasIndex(e => e.SessionVisiblility, "session_visibility_type");

            entity.HasIndex(e => e.WinnerUser, "session_winner");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Game)
                .HasColumnType("int(11)")
                .HasColumnName("game");
            entity.Property(e => e.HostUser)
                .HasColumnType("int(11)")
                .HasColumnName("host_user");
            entity.Property(e => e.SessionAssetsToken)
                .HasColumnType("text")
                .HasColumnName("session_assets_token");
            entity.Property(e => e.SessionEnd).HasColumnName("session_end");
            entity.Property(e => e.SessionEnded)
                .HasColumnType("int(11)")
                .HasColumnName("session_ended");
            entity.Property(e => e.SessionJoinToken)
                .HasColumnType("text")
                .HasColumnName("session_join_token");
            entity.Property(e => e.SessionStart).HasColumnName("session_start");
            entity.Property(e => e.SessionVisiblility)
                .HasColumnType("int(11)")
                .HasColumnName("session_visiblility");
            entity.Property(e => e.WinnerUser)
                .HasColumnType("int(11)")
                .HasColumnName("winner_user");

            entity.HasOne(d => d.GameNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.Game)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("session_game");

            entity.HasOne(d => d.HostUserNavigation).WithMany(p => p.SessionHostUserNavigations)
                .HasForeignKey(d => d.HostUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("host");

            entity.HasOne(d => d.SessionVisiblilityNavigation).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.SessionVisiblility)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("session_visibility_type");

            entity.HasOne(d => d.WinnerUserNavigation).WithMany(p => p.SessionWinnerUserNavigations)
                .HasForeignKey(d => d.WinnerUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("session_winner");
        });

        modelBuilder.Entity<SessionConnection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("session_connection");

            entity.HasIndex(e => e.Session, "session_id");

            entity.HasIndex(e => e.User, "user_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ConnectionDate).HasColumnName("connection_date");
            entity.Property(e => e.ConnectionStatus)
                .HasColumnType("int(11)")
                .HasColumnName("connection_status");
            entity.Property(e => e.Session)
                .HasColumnType("int(11)")
                .HasColumnName("session");
            entity.Property(e => e.User)
                .HasColumnType("int(11)")
                .HasColumnName("user");

            entity.HasOne(d => d.SessionNavigation).WithMany(p => p.SessionConnections)
                .HasForeignKey(d => d.Session)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("session_id");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.SessionConnections)
                .HasForeignKey(d => d.User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_id");
        });

        modelBuilder.Entity<SessionVisibility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("session_visibility");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Visibility)
                .HasColumnType("text")
                .HasColumnName("visibility");
        });

        modelBuilder.Entity<TwoFactorType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("two_factor_type");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Type)
                .HasColumnType("text")
                .HasColumnName("type");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.LoginStatus, "user_login_status");

            entity.HasIndex(e => e.TwoFactorType, "user_two_factor");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.EmailAdress)
                .HasColumnType("text")
                .HasColumnName("email_adress");
            entity.Property(e => e.FirstName)
                .HasColumnType("text")
                .HasColumnName("first_name");
            entity.Property(e => e.FirstSubscriptionDate).HasColumnName("first_subscription_date");
            entity.Property(e => e.HashedPassword)
                .HasColumnType("text")
                .HasColumnName("Hashed_password");
            entity.Property(e => e.InviteCode)
                .HasColumnType("text")
                .HasColumnName("invite_code");
            entity.Property(e => e.LastName)
                .HasColumnType("text")
                .HasColumnName("last_name");
            entity.Property(e => e.LastSubscriptionDate).HasColumnName("last_subscription_date");
            entity.Property(e => e.LoginStatus)
                .HasColumnType("int(11)")
                .HasColumnName("login_status");
            entity.Property(e => e.MiddleName)
                .HasColumnType("text")
                .HasColumnName("middle_name");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("text")
                .HasColumnName("phone_number");
            entity.Property(e => e.PrivateUsername)
                .HasColumnType("text")
                .HasColumnName("private_username");
            entity.Property(e => e.PublicUsername)
                .HasColumnType("text")
                .HasColumnName("public_username");
            entity.Property(e => e.Salt)
                .HasColumnType("text")
                .HasColumnName("salt");
            entity.Property(e => e.SubcriptionType)
                .HasColumnType("int(11)")
                .HasColumnName("subcription_type");
            entity.Property(e => e.SubscriptionTier)
                .HasColumnType("int(11)")
                .HasColumnName("subscription_tier");
            entity.Property(e => e.SubscriptionToken)
                .HasColumnType("text")
                .HasColumnName("subscription_token");
            entity.Property(e => e.TwoFactorToken)
                .HasColumnType("text")
                .HasColumnName("two_factor_token");
            entity.Property(e => e.TwoFactorType)
                .HasColumnType("int(11)")
                .HasColumnName("two_factor_type");
            entity.Property(e => e.UseTwoFactor)
                .HasColumnType("int(11)")
                .HasColumnName("use_two_factor");

            entity.HasOne(d => d.LoginStatusNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.LoginStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_login_status");

            entity.HasOne(d => d.TwoFactorTypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.TwoFactorType)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("user_two_factor");
        });

        modelBuilder.Entity<UserFavourite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_favourite");

            entity.HasIndex(e => e.GamePublicProfileId, "public_profile_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.BecameFavourite).HasColumnName("became_favourite");
            entity.Property(e => e.GamePublicProfileId)
                .HasColumnType("int(11)")
                .HasColumnName("game_public_profile_id");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.GamePublicProfile).WithMany(p => p.UserFavourites)
                .HasForeignKey(d => d.GamePublicProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("public_profile_id");
        });

        modelBuilder.Entity<UserFirend>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_firend");

            entity.HasIndex(e => e.FriendId, "friend_connection");

            entity.HasIndex(e => e.UserId, "user_connection");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FriendId)
                .HasColumnType("int(11)")
                .HasColumnName("friend_id");
            entity.Property(e => e.Friended).HasColumnName("friended");
            entity.Property(e => e.Nickname)
                .HasColumnType("text")
                .HasColumnName("nickname");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Friend).WithMany(p => p.UserFirendFriends)
                .HasForeignKey(d => d.FriendId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("friend_connection");

            entity.HasOne(d => d.User).WithMany(p => p.UserFirendUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_connection");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
