using Microsoft.EntityFrameworkCore;
using TaskFlowPro.Domain.Entities;
using TaskEntity = TaskFlowPro.Domain.Entities.Task;

namespace TaskFlowPro.Persistence.Data;

/// <summary>
/// Application database context for TaskFlow Pro
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSets for all entities
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Role entity
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId);
            entity.Property(e => e.RoleName)
                .IsRequired()
                .HasMaxLength(50);
            entity.HasIndex(e => e.RoleName)
                .IsUnique()
                .HasDatabaseName("UK_Roles_RoleName");
        });

        // Configure Team entity
        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId);
            entity.Property(e => e.TeamName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");

            entity.HasIndex(e => e.TeamName)
                .IsUnique()
                .HasDatabaseName("UK_Teams_TeamName");
            entity.HasIndex(e => e.LeaderId)
                .HasDatabaseName("IX_Teams_LeaderId");

            // Configure relationship with Leader (User)
            entity.HasOne(e => e.Leader)
                .WithMany(u => u.LeadingTeams)
                .HasForeignKey(e => e.LeaderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Teams_LeaderId");
        });

        // Configure User entity
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.LastTokenIssueAt)
                .HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");

            entity.HasIndex(e => e.Email)
                .IsUnique()
                .HasDatabaseName("UK_Users_Email");
            entity.HasIndex(e => e.RoleId)
                .HasDatabaseName("IX_Users_RoleId");
            entity.HasIndex(e => e.TeamId)
                .HasDatabaseName("IX_Users_TeamId");
            entity.HasIndex(e => new { e.TeamId, e.RoleId })
                .HasDatabaseName("IX_Users_Team_Role");
            entity.HasIndex(e => e.LastTokenIssueAt)
                .HasDatabaseName("IX_Users_TokenIssue");

            // Configure relationship with Role
            entity.HasOne(e => e.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Users_RoleId");

            // Configure relationship with Team
            entity.HasOne(e => e.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Users_TeamId");

            // Ignore computed property
            entity.Ignore(e => e.FullName);
        });

        // Configure Task entity
        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.HasKey(e => e.TaskId);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Description)
                .HasColumnType("NTEXT");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("GETDATE()");

            // Create indexes for performance
            entity.HasIndex(e => new { e.TeamId, e.Status })
                .HasDatabaseName("IX_Tasks_Team_Status");
            entity.HasIndex(e => new { e.AssignedToUserId, e.Status })
                .HasDatabaseName("IX_Tasks_Assignee_Status");
            entity.HasIndex(e => e.CreatedByUserId)
                .HasDatabaseName("IX_Tasks_Creator");
            entity.HasIndex(e => e.DueDate)
                .HasDatabaseName("IX_Tasks_DueDate");
            entity.HasIndex(e => e.Title)
                .HasDatabaseName("IX_Tasks_Title");
            entity.HasIndex(e => new { e.TeamId, e.AssignedToUserId, e.Status })
                .HasDatabaseName("IX_Tasks_Team_Assignee_Status");

            // Configure check constraint for status
            entity.HasCheckConstraint("CK_Tasks_Status",
                "Status IN ('Pending', 'In Progress', 'Completed', 'Overdue', 'Cancelled')");

            // Configure relationships
            entity.HasOne(e => e.Team)
                .WithMany(t => t.Tasks)
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Tasks_TeamId");

            entity.HasOne(e => e.AssignedToUser)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(e => e.AssignedToUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Tasks_AssignedTo");

            entity.HasOne(e => e.CreatedByUser)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Tasks_CreatedBy");

            // Ignore computed property
            entity.Ignore(e => e.IsOverdue);
        });

        // Seed initial data
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Roles
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, RoleName = "Global Administrator" },
            new Role { RoleId = 2, RoleName = "Team Leader" },
            new Role { RoleId = 3, RoleName = "Team Member" },
            new Role { RoleId = 4, RoleName = "User without Team" }
        );
    }
}
