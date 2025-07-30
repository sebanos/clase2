using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.Domain.Entities;

/// <summary>
/// Represents a user in the task management system
/// </summary>
public class User
{
    /// <summary>
    /// Unique identifier for the user
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Email address used for authentication (unique)
    /// </summary>
    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Hashed password for authentication
    /// </summary>
    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// User's first name
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// User's last name
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Foreign key to the user's role
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Foreign key to the user's team (nullable)
    /// </summary>
    public int? TeamId { get; set; }

    /// <summary>
    /// Timestamp of the last JWT token issue for token invalidation
    /// </summary>
    public DateTime LastTokenIssueAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the user was created
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Timestamp when the user was last updated
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    /// <summary>
    /// Reference to the user's role
    /// </summary>
    public virtual Role Role { get; set; } = null!;

    /// <summary>
    /// Reference to the user's team (if assigned)
    /// </summary>
    public virtual Team? Team { get; set; }

    /// <summary>
    /// Collection of teams where this user is the leader
    /// </summary>
    public virtual ICollection<Team> LeadingTeams { get; set; } = new List<Team>();

    /// <summary>
    /// Collection of tasks assigned to this user
    /// </summary>
    public virtual ICollection<Task> AssignedTasks { get; set; } = new List<Task>();

    /// <summary>
    /// Collection of tasks created by this user
    /// </summary>
    public virtual ICollection<Task> CreatedTasks { get; set; } = new List<Task>();

    /// <summary>
    /// Computed property for full name
    /// </summary>
    public string FullName => $"{FirstName} {LastName}";
}
