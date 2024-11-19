using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace CraftingTableBackend.Models;

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

    public virtual DbSet<FriendRequest> FriendRequests { get; set; }

    public virtual DbSet<FriendRequestStatus> FriendRequestStatuses { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameVisibility> GameVisibilities { get; set; }

    public virtual DbSet<LoginStatus> LoginStatuses { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<SessionConnection> SessionConnections { get; set; }

    public virtual DbSet<SessionVisibility> SessionVisibilities { get; set; }

    public virtual DbSet<TwoFactorType> TwoFactorTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFirend> UserFirends { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=craftingtable;user=root;ssl mode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

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
            entity.Property(e => e.GameRules)
                .HasColumnType("text")
                .HasColumnName("game_rules");
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
